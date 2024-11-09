using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Entities are used to model your domain

namespace eCommerce.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationship : One to many
        // One Category to Many product
        public ICollection<Product>? Products { get; set; }
    }
}
