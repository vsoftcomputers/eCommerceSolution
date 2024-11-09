using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Call Repositories/Methods here

namespace eCommerce.Domain.Interfaces.Authentication
{
    public interface IRoleManagement
    {
        Task<bool> AssignRole(string roleName, string userEmail);
      
    }
}
