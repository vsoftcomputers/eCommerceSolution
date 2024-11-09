using eCommerce.SharedLibrary.DTOs;
using eCommerce.SharedLibrary.DTOs.Product;

namespace FrontEnd.Services.Product
{
    public interface IProductService
    {
        Task<ServiceResponse> CreateProduct(CreateProduct product);
        Task<ServiceResponse> UpdateProduct(UpdateProduct product);
        Task<GetProduct> GetProduct(int id);
        Task<ServiceResponse> DeleteProduct(int id);
        Task<IEnumerable<GetProduct>> GetProducts();
    }
}
