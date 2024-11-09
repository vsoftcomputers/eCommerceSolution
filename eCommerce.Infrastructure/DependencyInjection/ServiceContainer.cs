using eCommerce.Domain.Interfaces;
using eCommerce.Infrastructure.Data;
using eCommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Builder;
using eCommerce.Infrastructure.Exceptions;
using eCommerce.Application.Services.Log;
using eCommerce.Infrastructure.Services.Log;
using eCommerce.Application.Services.Authentication;
using eCommerce.Domain.Interfaces.Authentication;
using eCommerce.Infrastructure.Repositories.Authentication;

//ServiceContainer

//  In.NET(and Blazor specifically), a Service Container is a component used to manage Dependency Injection (DI),
//  where it acts as a central registry for registering and resolving services and their dependencies.
//  The service container enables the application to automatically inject services into components, classes, or other services where they’re needed.

//  Key Concepts of Service Container in .NET:
//  Service Registration:
//  You register services in the service container, specifying their lifetime (how long they remain available).
//  The three common lifetimes are:
//      Singleton   : The service is created once and shared across the entire application.
//      Scoped      : A new instance is created per request(useful in web applications, especially Blazor Server).
//      Transient   : A new instance is created each time it is requested.
//  Registration typically happens in Startup.cs (for older .NET applications) or in Program.cs for newer Blazor and .NET 6+ applications.

//Dependency Injection is a design pattern used in software development to manage dependencies between objects. 
//Instead of an object creating its own dependencies, these dependencies are "injected" into the object from the outside. 	
//This makes the code more modular, easier to test, and more maintainable.
//Think of services as helpers that provide specific functionality. 
//			For example:
//			Data Services   : Handle CRUD operations with your backend.
//			Utility Services: Provide utility functions like logging or formatting dates.

namespace eCommerce.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,  IConfiguration config)
        {
            string connectionString = config.GetConnectionString("eCommerceConnectionString")!;
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<IUserManagement, UserManagement>();
            services.AddScoped<ITokenManagement, TokenManagement>();
            services.AddScoped<IRoleManagement, RoleManagement>();
            services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));
            return services;
        }

        // Use Exceptions
        public static IApplicationBuilder UseInfrastructureService(this IApplicationBuilder app)
        {
            app.UseMiddleware<HandlingExceptionsMiddleware>();
            return app;
        }
    }
}
