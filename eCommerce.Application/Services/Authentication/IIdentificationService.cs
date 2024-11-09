using eCommerce.SharedLibrary.DTOs;

using eCommerce.SharedLibrary.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services.Authentication
{
    public interface IIdentificationService
    {
        Task<ServiceResponse> CreateAccount(CreateAccount account);
        Task<LoginResponse> LoginAccount(LoginAccount account);
        
    }
}
