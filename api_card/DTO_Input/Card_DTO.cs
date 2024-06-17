using System.ComponentModel.DataAnnotations;

namespace api_card.DTO
{
    public class Card_DTO
    {
        [Required(ErrorMessage = "id is number")]
        public int? UserId { get; set; }

        public DateTime? OrderDate { get; set; }
        public string? Note { get; set; }


        public Card_DTO() { }

    }
}
