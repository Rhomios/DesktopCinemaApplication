using System;
using System.Collections.Generic;

namespace MyMoviesWPF.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Iduser { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? EMail { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
