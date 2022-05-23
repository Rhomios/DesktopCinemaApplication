using System;
using System.Collections.Generic;

namespace MyMoviesWPF.Models
{
    public partial class Movie
    {
        public int Idmovie { get; set; }
        public int? Idgenre { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? ProductYear { get; set; }
        public string? Languages { get; set; }
        public int? IdactorList { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Idorder { get; set; }
        public byte[]? Trailer { get; set; }

        public virtual ActorList? IdactorListNavigation { get; set; }
        public virtual Genre? IdgenreNavigation { get; set; }
        public virtual Order? IdorderNavigation { get; set; }
    }
}
