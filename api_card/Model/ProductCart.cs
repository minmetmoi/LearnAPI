namespace api_card.Model
{
    public partial class ProductCart
    {
        public ProductCart(int productId, int? cardId, int? quantity)
        {
            ProductId = productId;
            CardId = cardId;
            Quantity = quantity;

        }

        public int ProductId { get; set; }
        public int? CardId { get; set; }
        public int? Quantity { get; set; }
        public int ProCartId { get; set; }

        public virtual Cart? Card { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
