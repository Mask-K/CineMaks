using System;
using System.Collections.Generic;

namespace CineMaks
{
    public partial class Session
    {
        public Session()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdSession { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int IdFilm { get; set; }
        public int IdHall { get; set; }

        public virtual Film IdFilmNavigation { get; set; } = null!;
        public virtual Hall IdHallNavigation { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
