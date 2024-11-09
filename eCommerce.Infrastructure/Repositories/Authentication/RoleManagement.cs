using eCommerce.Domain.Interfaces.Authentication;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories.Authentication
{
    public class RoleManagement(AppDbContext context) : IRoleManagement
    {
        public async Task<bool> AssignRole(string roleName, string userEmail)
        {
            var user = await context.UserRoles.FirstOrDefaultAsync(r => r.UserEmail == userEmail);
            if(user == null)
                context.UserRoles.Add(new Domain.Entities.UserRole() { RoleName = roleName, UserEmail = userEmail });
            else
                user.RoleName = roleName;

            await context.SaveChangesAsync();
            return true;
        }
    }
}
