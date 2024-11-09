using AutoMapper;
using eCommerce.SharedLibrary.DTOs;
using eCommerce.SharedLibrary.DTOs.Product;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Interfaces;

//  Services refer to classes that contain business logic or data access code which can be shared across multiple components. 
//  They're a way to encapsulate the core functionality of your application, making it reusable and easily testable.

//  Think of services as helpers that provide specific functionality. 
//	    For example:
//	    Data Services   : Handle CRUD operations with your backend.
//	    Utility Services: Provide utility functions like logging or formatting dates.

namespace eCommerce.Application.Services.ProductServices
{
    public class ProductServices(IProduct productInterface, IMapper mapper) : IProductService
    {
        public async Task<ServiceResponse> AddProduct(CreateProduct product)
        {
          //  try
           // {
                var mappedProduct = mapper.Map<Product>(product);
                int result = await productInterface.AddProduct(mappedProduct);
                return result > 0 ? new ServiceResponse(true, "Product saved successfully") :
                    new ServiceResponse(false, "Error occurred in saving product");

           // }
           // catch (Exception ex)
           // {
            //    return new ServiceResponse(false, "Product could not be added");
           // }
        }

        public async Task<ServiceResponse> DeleteProduct(int id)
        {
            int result = await productInterface.DeleteProduct(id);
            if (result > 0)
                return new ServiceResponse(true, "Product deleted successfully");
            else
               return new ServiceResponse(false, "Product not found or fail to delete");
        }

        public async Task<GetProduct> GetProductById(int id)
        {
            var product = await productInterface.GetProductById(id);
            return  mapper.Map<GetProduct>(product);
        }

        public  async Task<IEnumerable<GetProduct>> GetProducts()
        {
            var products = await productInterface.GetProducts();
            return mapper.Map<IEnumerable<GetProduct>>(products);
        }

        public async Task<ServiceResponse> UpdateProduct(UpdateProduct product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            int result = await productInterface.UpdateProduct(mappedProduct);
            return result > 0 ? new ServiceResponse(true, "Product updated successfully") :
                new ServiceResponse(false, "Error occurred in updating product");
        }
    }
}
