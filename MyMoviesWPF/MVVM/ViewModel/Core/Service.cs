using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using MyMoviesWPF.Models;

namespace MyMoviesWPF.MVVM.ViewModel.Core
{
    public static class Service
    {
        public static MyMoviesDBContext db = new MyMoviesDBContext();

        public static MainViewModel MainViewModel { get; set; }
        public static Movie movie { get; set; }

        public static Page CurrentPage;
    }
}
