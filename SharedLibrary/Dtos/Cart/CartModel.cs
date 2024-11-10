using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos.Cart
{
    public class CartModel
    {
        public Guid CartId { get; set; } = Guid.NewGuid();
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Base64Image { get; set; }
        public int PurchaseQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => PurchaseQuantity * Price;
    }
}
