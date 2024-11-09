using eCommerce.SharedLibrary.DTOs;
using eCommerce.SharedLibrary.DTOs.Product;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace FrontEnd.Services.Product
{
    public class ProductService(HttpClient client) : IProductService
    {
        public async Task<ServiceResponse> CreateProduct(CreateProduct product)
        {
            var result = await client.PostAsJsonAsync("api/product/add", product);
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteProduct(int id)
        {
            var result = await client.DeleteAsync($"api/product/delete/{id}");
            var response =await result.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<GetProduct> GetProduct(int id)
        => await client.GetFromJsonAsync<GetProduct>($"api/product/single/{id}");

        public async Task<IEnumerable<GetProduct>> GetProducts()
        => await client.GetFromJsonAsync<IEnumerable<GetProduct>>("api/product/all");

        public async Task<ServiceResponse> UpdateProduct(UpdateProduct product)
        {
            var result = await client.PutAsJsonAsync("api/product/update", product);
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}
