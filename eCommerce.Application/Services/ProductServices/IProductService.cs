﻿using eCommerce.SharedLibrary.DTOs;
using eCommerce.SharedLibrary.DTOs.Product;

//Call Services here

//An interface in programming is like a contract or blueprint that defines a set of methods and properties without providing any implementation.
//It's a way to ensure that different classes share a common set of functionalities, even if they implement those functionalities differently.
//Interfaces help in achieving polymorphism, allowing different classes to be treated as the same type and enabling flexible and scalable code.

//Interfaces allow you to define a standard way to interact with repositories, making it easier to swap implementations or mock them for testing.

namespace eCommerce.Application.Services.ProductServices
{
    public interface IProductService
    {
        Task<ServiceResponse> AddProduct(CreateProduct product);
        Task<ServiceResponse> UpdateProduct(UpdateProduct product);
        Task<ServiceResponse> DeleteProduct(int id);
        Task<GetProduct> GetProductById(int id);
        Task<IEnumerable<GetProduct>> GetProducts();
    }
}
