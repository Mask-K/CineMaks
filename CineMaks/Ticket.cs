using System;
using System.Collections.Generic;

namespace CineMaks
{
    public partial class Ticket
    {
        public int IdTicket { get; set; }
        public int Place { get; set; }
        public int IdSession { get; set; }
        public int? IdUser { get; set; }

        public virtual Session IdSessionNavigation { get; set; } = null!;
        public virtual User? IdUserNavigation { get; set; }
    }
}
