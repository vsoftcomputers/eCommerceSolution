using eCommerce.Domain.Interfaces.Authentication;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories.Authentication
{
    internal class TokenManagement(IConfiguration config, AppDbContext context) : ITokenManagement
    {
        public string GenerateRefreshToken()
        {
            byte[] randomByte = new byte[64];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomByte);
            }
            return Convert.ToBase64String(randomByte);
        }

        public string GenerateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(2);
            var token = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: cred);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task SaveRefreshToken(string userEmail, string token)
        {
            context.RefreshTokens.Add(new Domain.Entities.RefreshToken { UserEmail = userEmail, Token = token });
            await context.SaveChangesAsync();
        }

        public async Task UpdateRefreshToken(string token)
        {
            var user = await context.RefreshTokens.FirstOrDefaultAsync(t=> t.Token == token);
            user.Token = token;
            await context.SaveChangesAsync();
        }
    }
}
