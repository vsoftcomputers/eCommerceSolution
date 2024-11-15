﻿
//Data Transfer Objects
//DTOs are used to transfer data, particularly between the client and server in a Blazor app
//They often contain only the data needed for a specific operation, reducing the amount of data transferred and improving performance.

using System.ComponentModel.DataAnnotations;

namespace eCommerce.SharedLibrary.DTOs.Product
{
    public class ProductBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, DeniedValues(0.00, ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [Required, DeniedValues(0, ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        [Required]
        public string Base64Image { get; set; }
    }
}
