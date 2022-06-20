using MyMoviesWPF.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoviesWPF.MVVM.ViewModel
{
    public class CartPageViewModel
    {
        public ObservableCollection<Movie> CartMoviesCollection;
        public CartPageViewModel()
        {
            CartMoviesCollection = Service.CartMoviesCollection;
        }
    }
}
