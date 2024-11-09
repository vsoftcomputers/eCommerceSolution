using eCommerce.Application.Mapping;
using eCommerce.Application.Services.Authentication;
using eCommerce.Application.Services.CategoryServices;
using eCommerce.Application.Services.ProductServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

//Dependency Injection is a design pattern used in software development to manage dependencies between objects. 
//Instead of an object creating its own dependencies, these dependencies are "injected" into the object from the outside. 	
//This makes the code more modular, easier to test, and more maintainable.
//Think of services as helpers that provide specific functionality. 
//			For example:
//			Data Services   : Handle CRUD operations with your backend.
//			Utility Services: Provide utility functions like logging or formatting dates.

namespace eCommerce.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<ICategoryService, CategoryServices>();
            services.AddScoped<IIdentificationService, IdentificationService>();
            return services;
        }
    }
}
