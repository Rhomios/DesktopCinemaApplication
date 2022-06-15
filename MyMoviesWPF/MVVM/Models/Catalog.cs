using System;
using System.Collections.Generic;

namespace MyMoviesWPF
{
    public partial class Catalog
    {
        public int CatalogId { get; set; }
        public int Idmovie { get; set; }
        public string Title { get; set; } = null!;

        public virtual Movie IdmovieNavigation { get; set; } = null!;
    }
}
