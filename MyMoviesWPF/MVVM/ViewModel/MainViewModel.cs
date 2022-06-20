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
            UpdateCartStr();
            Service.MainViewModel = this;
            _currentPage = new CatalogPage();
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









        //UserViewModel _userViewModel = new UserViewModel();

        //private BaseViewModel _toolbar = new UserViewModel();
        //private BaseViewModel _view    = new CatalogViewModel();


        //public BaseViewModel CurrentToolbar
        //{
        //    get { return _toolbar; }
        //    set
        //    {
        //        _toolbar = value;
        //        OnPropertyChanged();
        //    }
        //}
        //public BaseViewModel CurrentView
        //{
        //    get { return _view; }
        //    set
        //    {
        //        _view = value;
        //        OnPropertyChanged();
        //    }
        //}


    }
}
