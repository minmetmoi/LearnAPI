using System.ComponentModel.DataAnnotations;

namespace api_card.Model
{
    public partial class ProductCart
    {
        public ProductCart(int productId, int? cardId, int quantity)
        {
            ProductId = productId;
            CardId = cardId;
            Quantity = quantity;
        }
        [Required(ErrorMessage = "id is number")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "id is number")]
        public int? CardId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = " phải lớn hơn 0.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "id is number")]
        public int ProCartId { get; set; }

        public virtual Cart? Card { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
