using System;
using System.Collections.Generic;

namespace MyMoviesWPF
{
    public partial class ActorList
    {
        public int IdactorList { get; set; }
        public int Idactor { get; set; }
        public int ListNum { get; set; }

        public virtual Actor IdactorNavigation { get; set; } = null!;
    }
}
