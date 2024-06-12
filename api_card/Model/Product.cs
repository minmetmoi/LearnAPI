using System;
using System.Collections.Generic;

namespace api_card.Model
{
    public partial class Product
    {
        public Product()
        {
            ProductCarts = new HashSet<ProductCart>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? Price { get; set; }
        public string? Desciption { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductCart> ProductCarts { get; set; }
    }
}
