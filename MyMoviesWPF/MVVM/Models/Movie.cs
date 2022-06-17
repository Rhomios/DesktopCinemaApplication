using System;
using System.Collections.Generic;

namespace MyMoviesWPF
{
    public partial class Movie
    {
        public Movie()
        {
            Catalogs = new HashSet<Catalog>();
        }
        public Movie(Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Movie, string> includableQueryable)
        {
            Catalogs = new HashSet<Catalog>();
        }

        public int Idmovie { get; set; }
        public int? Idgenre { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? ProductYear { get; set; }
        public string? Languages { get; set; }
        public int? IdactorList { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Idorder { get; set; }
        public string? Trailer { get; set; }
        public string? Image { get; set; }

        //public virtual ActorList? IdactorListNavigation { get; set; }
        public virtual Genre? IdgenreNavigation { get; set; }
        public virtual Order? IdorderNavigation { get; set; }
        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
