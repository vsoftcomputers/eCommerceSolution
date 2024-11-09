using eCommerce.Infrastructure.DependencyInjection;
using eCommerce.Application.DependencyInjection;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS => Cross Origin Resource Sharing
// Happen between Server -> Client
// Adding CORS
builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(options =>
    {
        options.AllowAnyHeader() // Authorization Header, custom Headers
        .AllowAnyMethod()  // GET, POST, PUT, Delete, Update
        .WithOrigins("https://localhost:7069")
        .AllowCredentials();
    });
});

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext().WriteTo.Console()
    .WriteTo.File("Log/Log.txt",rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddApplicationService();

Log.Logger.Information("Application is building");
try
{
    var app = builder.Build();

    // CORS => Cross Origin Resource Sharing
    // Happen between Server -> Client
    app.UseCors();
    app.UseInfrastructureService();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    Log.Logger.Information("Application is running");

    app.Run();
}catch(Exception ex)
{
    Log.Logger.Error(ex, "Failed to Start");
}
finally
{
    Log.CloseAndFlush();
}
