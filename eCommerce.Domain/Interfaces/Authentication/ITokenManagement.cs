using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

//Call Repositories/Methods here

namespace eCommerce.Domain.Interfaces.Authentication
{
    public interface ITokenManagement
    {
        string GenerateToken(List<Claim> claims);
        string GenerateRefreshToken();
        Task SaveRefreshToken(string userEmail, string token);
        Task UpdateRefreshToken( string token);
    }
}
