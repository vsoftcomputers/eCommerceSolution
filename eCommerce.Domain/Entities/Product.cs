using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Entities are used to model your domain

namespace eCommerce.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string Base64Image { get; set; }

        public DateTime CreatedDate { get; set; }

        // Relationship : many to One
        public Category? Category { get; set; }
        
        //Foreign Key
        public int CategoryId { get; set; }
    }
}
