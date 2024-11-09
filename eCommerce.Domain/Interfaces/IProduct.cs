using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Call Repositories/Methods here
//An interface in programming is like a contract or blueprint that defines a set of methods and properties without providing any implementation.
//It's a way to ensure that different classes share a common set of functionalities, even if they implement those functionalities differently.
//Interfaces help in achieving polymorphism, allowing different classes to be treated as the same type and enabling flexible and scalable code.

//Interfaces allow you to define a standard way to interact with repositories, making it easier to swap implementations or mock them for testing.

namespace eCommerce.Domain.Interfaces
{
    public interface IProduct
    {
        Task<int> AddProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts();
    }
}
