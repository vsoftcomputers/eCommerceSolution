using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class UserRole
    {
        public  int Id { get; set; }
        public string RoleName  { get; set; }
        public string UserEmail  { get; set; }
    }
}
