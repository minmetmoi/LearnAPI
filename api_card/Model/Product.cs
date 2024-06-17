using System.ComponentModel.DataAnnotations;

namespace api_card.Model
{
    public partial class Product
    {
        public Product()
        {
            ProductCarts = new HashSet<ProductCart>();
        }
        [Required(ErrorMessage = "id is number")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "not null please")]
        public string? ProductName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = " phải lớn hơn 0.")]
        public int? Price { get; set; }
        public string? Desciption { get; set; }
        [Required(ErrorMessage = "id is number")]
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductCart> ProductCarts { get; set; }
    }
}
