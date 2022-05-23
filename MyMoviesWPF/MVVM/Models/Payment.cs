using System;
using System.Collections.Generic;

namespace MyMoviesWPF.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int Idpayment { get; set; }
        public string PaymentType { get; set; } = null!;
        public decimal Sum { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
