using System.ComponentModel.DataAnnotations;

namespace api_card.Model
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
        }
        [Required(ErrorMessage = "id is number")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "not null pls")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "not null pls")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "not null pls")]
        public string? Location { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
