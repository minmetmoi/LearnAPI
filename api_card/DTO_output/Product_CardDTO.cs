using System.ComponentModel.DataAnnotations;

namespace api_card.DTO_output
{
    public class Product_CardDTO
    {
        [Required(ErrorMessage = "ten sản phẩm không được để trống")]
        public string? ProductName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = " phải lớn hơn 0.")]
        public int? Quantity { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = " phải lớn hơn 0.")]
        public int? Price { get; set; }
    }
}
