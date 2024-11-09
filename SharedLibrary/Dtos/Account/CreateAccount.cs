using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.SharedLibrary.DTOs.Account
{
    public class CreateAccount : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
