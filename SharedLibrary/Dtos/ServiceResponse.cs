
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//A Service Response typically refers to the structure or format of the data returned by a service. 
//When a client (like a web or mobile app) makes a request to a service (like an API), the service processes that request and sends back a response.
//A well-designed service response often includes:
//			Status Information  : Indicates the success or failure of the request (e.g., HTTP status codes like 200 OK, 404 Not Found, 500 Internal Server Error).
//			Data Payload		: Contains the actual data requested or a result of some processing (e.g., user details, list of items, etc.).
//			Metadata		: Additional information about the response, like pagination details for lists or timestamps.

namespace eCommerce.SharedLibrary.DTOs
{
    public record ServiceResponse(bool Success = false, string Message = null!);
}

