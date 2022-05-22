using System;
using System.Collections.Generic;

namespace MyMoviesWPF.Models
{
    public partial class Order
    {
        public Order()
        {
            Movies = new HashSet<Movie>();
        }

        public int Idorder { get; set; }
        public int Iduser { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
        public int? Idpayment { get; set; }

        public virtual Payment? IdpaymentNavigation { get; set; }
        public virtual User IduserNavigation { get; set; } = null!;
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
