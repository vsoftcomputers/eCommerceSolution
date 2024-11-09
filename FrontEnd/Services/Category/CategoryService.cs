using eCommerce.SharedLibrary.DTOs;
using eCommerce.SharedLibrary.DTOs.Category;
using eCommerce.SharedLibrary.DTOs.Product;
using System.Net.Http.Json;

namespace FrontEnd.Services.Category
{
    public class CategoryService (HttpClient client) : ICategoryService
    {
        public async Task<ServiceResponse> CreateCategory(CreateCategory category)
        {
            var result = await client.PostAsJsonAsync("api/category/add", category);
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteCategory(int id)
        {
            var result = await client.DeleteAsync($"api/category/delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<IEnumerable<GetCategory>> GetCategories()
        => await client.GetFromJsonAsync<IEnumerable<GetCategory>>($"api/category/all");

        public async Task<GetCategory> GetCategory(int id)
         => await client.GetFromJsonAsync<GetCategory>($"api/category/single/{id}");

        public async Task<ServiceResponse> UpdateCategory(UpdateCategory category)
        {
            var result = await client.PutAsJsonAsync("api/category/update", category);
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}
