using eCommerce.Application.Services.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

// Exceptions represent errors or unexpected behaviors that occur during the app's runtime. 
// They can interrupt the normal execution flow of the application and,
// if unhandled, can cause the application to crash or behave unpredictably. 
// Exceptions in Blazor apps work similarly to exceptions in other .NET applications,
// but they require particular handling in the Blazor context, especially because Blazor apps involve both server-side and client-side logic.

// Common Exceptions in Blazor Apps:
//			NullReferenceException: Often occurs when a null object is accessed. This is common in Blazor if a component or data object hasn't fully loaded or initialized.
//			InvalidOperationException: Can occur when a Blazor component or its child components are in an invalid state.
//			HttpRequestException: Often occurs when fetching data from an API fails due to network issues, invalid URLs, or API errors.
//			DbUpdateException: Occurs in data access operations, typically when using Entity Framework Core and there's a database issue.
//			UnauthorizedAccessException: Triggered when a user tries to access a resource they don't have permission for.

namespace eCommerce.Infrastructure.Exceptions
{
    public class HandlingExceptionsMiddleware(RequestDelegate  next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
              await next(context);
            }
            catch(Exception ex)
            {
                
                context.Response.ContentType = "application/json";
                if (ex is SqlException)
                {
                    
                    await context.Response.WriteAsync("Error occurred in performing operation in the database", CancellationToken.None);
                }
                else if (ex is DbUpdateException)
                {

                    await context.Response.WriteAsync("Error occurred in performing operation in the database", CancellationToken.None);
                }
                else 
                {
                    await context.Response.WriteAsync("Unknown Error occurred", CancellationToken.None);

                }
            }
        }
    }
}
