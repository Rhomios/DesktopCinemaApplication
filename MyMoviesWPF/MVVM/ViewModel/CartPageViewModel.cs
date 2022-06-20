using Microsoft.Toolkit.Mvvm.Input;
using MyMoviesWPF.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;


namespace MyMoviesWPF.MVVM.ViewModel
{
    public class CartPageViewModel : BaseViewModel
    {
        private ObservableCollection<Movie> _cartMoviesCollection;
        private Movie _removeMovie;
        public CartPageViewModel()
        {
            _cartMoviesCollection = Service.CartMoviesCollection;
            OnPropertyChanged("CartMoviesCollection");
        }
        public ObservableCollection<Movie> CartMoviesCollection
        {
            get { return _cartMoviesCollection; }
            set
            {
                if (_cartMoviesCollection == value)
                    return;

                _cartMoviesCollection = value;
                OnPropertyChanged("CartMoviesCollection");
            }
        }

        public Movie RemoveMovie
        {
            get
            {
                return _removeMovie;
            }
            set
            {
                if (MessageBox.Show("Вы действительно хотите убрать этот фильм из корзины?",
                "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var itemToRemove = Service.CartMoviesCollection.Single(r => r.Idmovie == Service.movie.Idmovie);
                    Service.CartMoviesCollection.Remove(itemToRemove);
                    _cartMoviesCollection = Service.CartMoviesCollection;
                    OnPropertyChanged("CartMoviesCollection");
                    Service.MainViewModel.UpdateCartStr();

                }
                else
                {
                    // Do not close the window  
                }
            }
        }


    }
}
