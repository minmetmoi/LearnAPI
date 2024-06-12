using System;
using System.Collections.Generic;

namespace api_card.Model
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
