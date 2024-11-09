using AutoMapper;
using eCommerce.SharedLibrary.DTOs.Account;
using eCommerce.SharedLibrary.DTOs.Category;
using eCommerce.SharedLibrary.DTOs.Product;
using eCommerce.Domain.Entities;

//  Mapping can refer to different things based on the context. 
//  In the realm of software development, it often means transforming data from one format or structure to another.
//  Here are a couple of common contexts:

//	Object - Relational Mapping(ORM): 
//	This involves mapping objects in your code to database tables. 
//	For instance, with Entity Framework in C#, you can map a class like Order to an Orders table in a database.
//	public class Order
//  {
//    public int OrderId { get; set; }
//    public string ProductName { get; set; }
//    public int Quantity { get; set; }
//  }
//  Using an ORM tool, you save and retrieve instances of Order from the database without writing SQL queries directly.
//	Data Transfer Objects (DTOs): 
//  When you're transferring data between layers or over a network, you often need to map domain objects to DTOs and vice versa. 
//  This keeps your domain models clean and decouples them from external concerns.
//  So, mapping is all about transforming data to fit different contexts or purposes, making your application more versatile and easier to manage.

namespace eCommerce.Application.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            // Mapping  From   =>      To
            CreateMap<CreateProduct, Product>();
            CreateMap<UpdateProduct, Product>();
            CreateMap<Product, GetProduct>();

            CreateMap<CreateCategory, Category>();
            CreateMap<UpdateCategory, Category>();
            CreateMap<Category, GetCategory>();

            CreateMap<CreateAccount, AppUser>();
            CreateMap<LoginAccount, AppUser>();
        }
    }
}
