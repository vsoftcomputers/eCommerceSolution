using eCommerce.SharedLibrary.DTOs.Category;
using eCommerce.SharedLibrary.DTOs.Product;
//Data Transfer Objects
//DTOs are used to transfer data, particularly between the client and server in a Blazor app
//They often contain only the data needed for a specific operation, reducing the amount of data transferred and improving performance.

namespace eCommerce.SharedLibrary.DTOs.Product
{
    public class GetProduct : ProductBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        // Relationship
        public GetCategory? Category { get; set; }


    }
}
