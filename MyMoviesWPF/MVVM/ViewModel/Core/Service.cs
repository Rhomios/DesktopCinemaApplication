using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMoviesWPF.Models;

namespace MyMoviesWPF.MVVM.ViewModel.Core
{
    public static class Service
    {
        public static MyMoviesDBContext db = new MyMoviesDBContext();

        public static Movie movie { get; set; }

    }
}
