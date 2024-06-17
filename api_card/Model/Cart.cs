using System.ComponentModel.DataAnnotations;

namespace api_card.Model
{
    public partial class Cart
    {
        public Cart()
        {
            ProductCarts = new HashSet<ProductCart>();
        }
        [Required(ErrorMessage = "id is number")]
        public int CartId { get; set; }
        [Required(ErrorMessage = "id is number")]
        public int? UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Note { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<ProductCart> ProductCarts { get; set; }
    }
}
