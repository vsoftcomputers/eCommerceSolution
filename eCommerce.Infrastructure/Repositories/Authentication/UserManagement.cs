using eCommerce.Domain.Entities;
using eCommerce.Domain.Interfaces.Authentication;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories.Authentication
{
    public class UserManagement(AppDbContext context) : IUserManagement
    {
        public async Task<int> CreateAccount(AppUser user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            context.Users.Add(user);
            return await context.SaveChangesAsync();
        }

        public async Task<AppUser> GetCurrentUser(string email)
        {
            var _user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return _user is null ? null! : _user;
        }

        public async Task<List<Claim>> GetUserClaims(string userEmail)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user == null) return [];

            var userRole = await context.UserRoles.FirstOrDefaultAsync(u => u.UserEmail == userEmail);
            if (userRole == null) return [];

            List<Claim> claims = [
                new Claim("Fullname", user!.Name),
                new Claim(ClaimTypes.NameIdentifier, user!.Id.ToString()),
                new Claim(ClaimTypes.Email, user!.Email!),
                new Claim(ClaimTypes.Role, userRole.RoleName!)
               ];
            return claims;
        }

        public async Task<IEnumerable<AppUser>> GetUserList()
        => await context.Users.ToListAsync();

        public async Task<bool> LoginAccount(AppUser user)
        {
            var _user = await context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (BCrypt.Net.BCrypt.Verify(user.Password, _user!.Password))
                return true;
            else
                return false;
        }
    }
}
