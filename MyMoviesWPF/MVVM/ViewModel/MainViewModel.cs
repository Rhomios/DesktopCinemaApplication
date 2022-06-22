using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MyMoviesWPF.MVVM.View.Pages;
using MyMoviesWPF.MVVM.ViewModel.Core;


namespace MyMoviesWPF.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string str;

        ObservableCollection<User> user = new ObservableCollection<User>(Service.db.Users.ToList());

        private RelayCommand _openCart;
        public Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public string Cart
        {
            get 
            {
                return str; 
            }
            set
            {
                if (str == value)
                    return;
                str = value;
                OnPropertyChanged("Cart");
            }
        }


        public MainViewModel()
        {
            Service.LoggedUser = user[0];
            UpdateCartStr();
            Service.MainViewModel = this;
            UpdatePage(Service.catalogPage);
        }



        public void UpdatePage(Page _page)
        {
            _currentPage = _page;
            OnPropertyChanged("CurrentPage");
        }

        
        public void UpdateCartStr()
        {
            if (Service.CartMoviesCollection.Count > 0)
            {
                str = "Корзина(" + (Service.CartMoviesCollection.Count) + ')';
            }
            else
            {
                str = "Корзина";
            }
            OnPropertyChanged("Cart");
        }
        public RelayCommand OpenCart
        {
            get
            {
                return _openCart
                  ?? (_openCart = new RelayCommand(
                    async () =>
                    {
                        CartPage page = new CartPage();
                        UpdatePage(page);
                    }));
            }
        }

    }
}
