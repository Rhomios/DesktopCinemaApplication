using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using MyMoviesWPF.Models;
using MyMoviesWPF.MVVM.View.Pages;

namespace MyMoviesWPF.MVVM.ViewModel.Core
{
    public static class Service
    {
        public static MyMoviesDBContext db = new MyMoviesDBContext();

        public static User LoggedUser = new User();
        public static CatalogPage catalogPage = new CatalogPage();
        public static ObservableCollection<Movie> CartMoviesCollection { get; set; } = new ObservableCollection<Movie>();
        public static MainViewModel MainViewModel { get; set; }
        public static Movie movie { get; set; }

        public static Page CurrentPage;
    }
}
