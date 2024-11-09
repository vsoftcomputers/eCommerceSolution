using AutoMapper;
using eCommerce.SharedLibrary.DTOs;
using eCommerce.SharedLibrary.DTOs.Category;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

//  Services refer to classes that contain business logic or data access code which can be shared across multiple components. 
//  They're a way to encapsulate the core functionality of your application, making it reusable and easily testable.

//  Think of services as helpers that provide specific functionality. 
//	    For example:
//	    Data Services   : Handle CRUD operations with your backend.
//	    Utility Services: Provide utility functions like logging or formatting dates.

namespace eCommerce.Application.Services.CategoryServices
{
    public class CategoryServices(ICategory CategoryInterface, IMapper mapper) : ICategoryService
    {
        public async Task<ServiceResponse> AddCategory(CreateCategory Category)
        {
            var mappedCategory = mapper.Map<Category>(Category);
            int result = await CategoryInterface.AddCategory(mappedCategory);
            return result > 0 ? new ServiceResponse(true, "Category saved successfully") :
                new ServiceResponse(false, "Error occurred in saving Category");

            //if (result > 0)
            //    return new ServiceResponse(true, "Category saved successfully");
            //else
            //    new ServiceResponse(false, "Error occurred in saving Category");
        }

        public async Task<ServiceResponse> DeleteCategory(int id)
        {
            int result = await CategoryInterface.DeleteCategory(id);
            if (result > 0)
                return new ServiceResponse(true, "Category deleted successfully");
            else
                return new ServiceResponse(false, "Category not found or fail to delete");
        }

        public async Task<GetCategory> GetCategoryById(int id)
        {
            var Category = await CategoryInterface.GetCategoryById(id);
            return mapper.Map<GetCategory>(Category);
        }

        public async Task<IEnumerable<GetCategory>> GetCategories()
        {
            var Categories = await CategoryInterface.GetCategories();
            return mapper.Map<IEnumerable<GetCategory>>(Categories);
        }

        public async Task<ServiceResponse> UpdateCategory(UpdateCategory Category)
        {
            var mappedCategory = mapper.Map<Category>(Category);
            int result = await CategoryInterface.UpdateCategory(mappedCategory);
            return result > 0 ? new ServiceResponse(true, "Category updated successfully") :
                new ServiceResponse(false, "Error occurred in updating Category");
        }
    }
}
