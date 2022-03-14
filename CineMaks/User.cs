using System;
using System.Collections.Generic;

namespace CineMaks
{
    public partial class User
    {
        public User()
        {
            OrderCarts = new HashSet<OrderCart>();
            Tickets = new HashSet<Ticket>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<OrderCart> OrderCarts { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
