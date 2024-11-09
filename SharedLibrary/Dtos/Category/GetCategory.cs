﻿using eCommerce.SharedLibrary.DTOs.Product;
//Data Transfer Objects
//DTOs are used to transfer data, particularly between the client and server in a Blazor app
//They often contain only the data needed for a specific operation, reducing the amount of data transferred and improving performance.

namespace eCommerce.SharedLibrary.DTOs.Category
{
    public class GetCategory : CategoryBase
    {
        public int Id { get; set; }
        public ICollection<GetProduct>? Products { get; set; }
    }
}