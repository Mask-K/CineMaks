using System;
using System.Collections.Generic;

namespace CineMaks
{
    public partial class FilmType
    {
        public FilmType()
        {
            Films = new HashSet<Film>();
        }

        public int IdType { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Film> Films { get; set; }
    }
}
