using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Token { get; set; }
    }
}
