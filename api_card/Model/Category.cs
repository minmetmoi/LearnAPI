using System.ComponentModel.DataAnnotations;

namespace api_card.Model
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [Required(ErrorMessage = "id is number")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "not null pls")]
        public string? CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
