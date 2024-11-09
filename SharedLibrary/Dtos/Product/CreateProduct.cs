using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Data Transfer Objects
//DTOs are used to transfer data, particularly between the client and server in a Blazor app
//They often contain only the data needed for a specific operation, reducing the amount of data transferred and improving performance.

namespace eCommerce.SharedLibrary.DTOs.Product
{
    public class CreateProduct : ProductBase
    {
        public int CategoryId { get; set; }
    }
}
