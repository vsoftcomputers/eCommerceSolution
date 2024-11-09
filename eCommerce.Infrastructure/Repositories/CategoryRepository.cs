using eCommerce.Domain.Entities;
using eCommerce.Domain.Interfaces;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

//  Define Repositories/Methods here
//  A repository is a pattern used to manage data access and manipulation.
//  Think of it as an intermediary between your application's business logic and the data sources it needs to interact with. 
//  It abstracts the details of how data is retrieved, stored, and updated, so your business logic doesn't have to worry about it.

namespace eCommerce.Infrastructure.Repositories
{
    public class CategoryRepository(AppDbContext context) : ICategory
    {
        public async Task<int> AddCategory(Category category)
        {
            context.Categories.Add(category);
            int result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteCategory(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category is null) return 0;

            context.Categories.Remove(category);
            int result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category == null) return null!;
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await context.Categories.AsNoTracking().ToListAsync();
            if (categories == null) return null!;
            return categories;
        }

        public async Task<int> UpdateCategory(Category category)
        {
            context.Categories.Update(category);
            int result = await context.SaveChangesAsync();
            return result;
        }
    }
}
