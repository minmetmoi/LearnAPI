using System;
using System.Collections.Generic;

namespace api_card.Model
{
    public partial class Cart
    {
        public Cart()
        {
            ProductCarts = new HashSet<ProductCart>();
        }

        public int CartId { get; set; }
        public int? UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Note { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<ProductCart> ProductCarts { get; set; }
    }
}
