
//Data Transfer Objects

//DTOs are used to transfer data, particularly between the client and server in a Blazor app
//They often contain only the data needed for a specific operation, reducing the amount of data transferred and improving performance.

using System.ComponentModel.DataAnnotations;

namespace eCommerce.SharedLibrary.DTOs.Category
{
    public class CategoryBase
    {
        [Required]
        public string Name { get; set; }
    }
}
