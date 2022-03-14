using System;
using System.Collections.Generic;

namespace CineMaks
{
    public partial class Hall
    {
        public Hall()
        {
            Sessions = new HashSet<Session>();
        }

        public int IdHall { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
