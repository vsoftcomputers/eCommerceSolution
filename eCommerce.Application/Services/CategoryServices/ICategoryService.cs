using eCommerce.SharedLibrary.DTOs.Category;
using eCommerce.SharedLibrary.DTOs;

//Call Services here

//An interface in programming is like a contract or blueprint that defines a set of methods and properties without providing any implementation.
//It's a way to ensure that different classes share a common set of functionalities, even if they implement those functionalities differently.
//Interfaces help in achieving polymorphism, allowing different classes to be treated as the same type and enabling flexible and scalable code.

//Interfaces allow you to define a standard way to interact with repositories, making it easier to swap implementations or mock them for testing.

namespace eCommerce.Application.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<ServiceResponse> AddCategory(CreateCategory category);
        Task<ServiceResponse> UpdateCategory(UpdateCategory category);
        Task<ServiceResponse> DeleteCategory(int id);
        Task<GetCategory> GetCategoryById(int id);
        Task<IEnumerable<GetCategory>> GetCategories();
    }
}
