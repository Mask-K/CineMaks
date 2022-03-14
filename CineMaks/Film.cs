using System;
using System.Collections.Generic;

namespace CineMaks
{
    public partial class Film
    {
        public Film()
        {
            Sessions = new HashSet<Session>();
        }

        public int IdFilm { get; set; }
        public int IdType { get; set; }
        public string Name { get; set; } = null!;
        public string ShortDesc { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual FilmType IdTypeNavigation { get; set; } = null!;
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
