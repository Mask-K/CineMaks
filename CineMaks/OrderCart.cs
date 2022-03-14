using System;
using System.Collections.Generic;

namespace CineMaks
{
    public partial class OrderCart
    {
        public int IdOrderCart { get; set; }
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
