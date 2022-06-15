using System;
using System.Collections.Generic;

namespace MyMoviesWPF
{
    public partial class Actor
    {
        public Actor()
        {
            ActorLists = new HashSet<ActorList>();
        }

        public int Idactor { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<ActorList> ActorLists { get; set; }
    }
}
