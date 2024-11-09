using eCommerce.Application.Services.Log;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Interfaces;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

//  Define Repositories/Methods here
//  A repository is a pattern used to manage data access and manipulation.
//  Think of it as an intermediary between your application's business logic and the data sources it needs to interact with. 
//  It abstracts the details of how data is retrieved, stored, and updated, so your business logic doesn't have to worry about it.

namespace eCommerce.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context, IAppLogger<ProductRepository> logger) : IProduct
    {
        public async Task<int> AddProduct(Product product)
        {
            try
            {
                context.Products.Add(product);
                int result = await context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Product Adding Exception");
                return 0;
            }
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product is null) return 0;

            context.Products.Remove(product);
            int result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null) return null!;
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await context.Products.AsNoTracking().ToListAsync();
            if (products == null) return null!;
            return products;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            context.Products.Update(product);
            int result = await context.SaveChangesAsync();
            return result;
        }
    }
}
