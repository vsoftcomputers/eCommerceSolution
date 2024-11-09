using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

//Call Repositories/Methods here

namespace eCommerce.Domain.Interfaces.Authentication
{
    public interface IUserManagement
    {
        Task<int> CreateAccount(AppUser user);
        Task<bool> LoginAccount(AppUser user);
        Task<List<Claim>> GetUserClaims(string userEmail);
        Task<IEnumerable<AppUser>> GetUserList();
        Task<AppUser> GetCurrentUser(string email);
    }
}
