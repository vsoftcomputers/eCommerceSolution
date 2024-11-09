using eCommerce.SharedLibrary.DTOs.Category;
using eCommerce.SharedLibrary.DTOs;

namespace FrontEnd.Services.Category
{
    public interface ICategoryService
    {
        Task<ServiceResponse> CreateCategory(CreateCategory category);
        Task<ServiceResponse> UpdateCategory(UpdateCategory category);
        Task<GetCategory> GetCategory(int id);
        Task<ServiceResponse> DeleteCategory(int id);
        Task<IEnumerable<GetCategory>> GetCategories();
    }
}
