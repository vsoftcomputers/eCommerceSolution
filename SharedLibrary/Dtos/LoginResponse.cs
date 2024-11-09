using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.SharedLibrary.DTOs
{
    public class LoginResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public string JWTToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
