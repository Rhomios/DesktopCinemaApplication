using System;
using System.Collections.Generic;

namespace MyMoviesWPF
{
    public partial class Order
    {
        public int Idorder { get; set; }
        public int Iduser { get; set; }
        public int? Idmovie { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
        public int? Idpayment { get; set; }

        public virtual Movie? IdmovieNavigation { get; set; }
        public virtual Payment? IdpaymentNavigation { get; set; }
        public virtual User IduserNavigation { get; set; } = null!;
    }
}
