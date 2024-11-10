using FrontEnd;
using FrontEnd.Services.Category;
using FrontEnd.Services.Product;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NetcodeHub.Packages.Extensions.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddNetcodeHubLocalStorageService();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7289/") });

await builder.Build().RunAsync();
