using AutoMapper;
using eCommerce.SharedLibrary.DTOs;
using eCommerce.Application.Services.Log;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Interfaces.Authentication;
using eCommerce.SharedLibrary.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eCommerce.Application.Services.Authentication
{
    public class IdentificationService(IAppLogger<IdentificationService> logger, IUserManagement userManagement, IMapper mapper, IRoleManagement roleManagement, ITokenManagement tokenManagement) : IIdentificationService
    {


        public async Task<ServiceResponse> CreateAccount(CreateAccount account)
        {
            var user = await userManagement.GetCurrentUser(account.Email);
            if (user is not null)
                return new ServiceResponse { Success = false, Message = "User already exist" };

            var mappedData = mapper.Map<AppUser>(account);
            try
            {
                await userManagement.CreateAccount(mappedData);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Creating User {JsonSerializer.Serialize(account)}");
                return new ServiceResponse { Success = false, Message = "Error occurred in creating account" };
            }

            var userList = await userManagement.GetUserList();
            if ((userList.Count() == 1))
                await roleManagement.AssignRole("Admin", account.Email);
            else
                await roleManagement.AssignRole("User", account.Email);
            return new ServiceResponse { Success = true, Message = "Account created successfully" };

        }


        public async Task<LoginResponse> LoginAccount(LoginAccount account)
        {
            var user = await userManagement.GetCurrentUser(account.Email);
            if (user is null)
                return new LoginResponse { Success = false, Message = "User not found" };

            var mappedData = mapper.Map<AppUser>(account);
            bool checkPassword = await userManagement.LoginAccount(mappedData);
            if (!checkPassword)
                return new LoginResponse { Success = false, Message = "Invalid Email/Password" };

            var claims = await userManagement.GetUserClaims(user.Email);
            string jwtToken = tokenManagement.GenerateToken(claims);
            string refreshToken = tokenManagement.GenerateRefreshToken();
            await tokenManagement.SaveRefreshToken(user.Email, refreshToken);
            return new LoginResponse { Success = true,Message="Success", JWTToken = jwtToken, RefreshToken=refreshToken};
        }
    }
}
