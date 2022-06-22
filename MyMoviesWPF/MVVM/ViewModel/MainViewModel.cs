using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MyMoviesWPF.MVVM.View;
using MyMoviesWPF.MVVM.View.Pages;
using MyMoviesWPF.MVVM.ViewModel.Core;


namespace MyMoviesWPF.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string str;
        private RelayCommand _openLogInView;
        private Visibility _authVis;
        private Visibility _nameVis;
        private User _user;

        ObservableCollection<User> user = new ObservableCollection<User>(Service.db.Users.ToList());

        private RelayCommand _openCart;
        public Page _currentPage;


        public User User
        {
            get { return _user; }
            set
            {
                if (_user == value)
                    return;

                _user = value;
                OnPropertyChanged("User");
            }
        }

        public RelayCommand OpenLogInView
        {
            get
            {
                return _openLogInView
                  ?? (_openLogInView = new RelayCommand(
                    async () =>
                    {
                        LogInView logInView = new LogInView();
                        logInView.Show();
                    }));
            }
        }

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

        public Visibility AuthVis
        {
            get
            {
                return _authVis;
            }
            set
            {
                _authVis = value;

                OnPropertyChanged("AuthVis");
            }
        }

        public Visibility NameVis
        {
            get
            {
                return _nameVis;
            }
            set
            {
                _nameVis = value;

                OnPropertyChanged("NameVis");
            }
        }
        public MainViewModel()
        {
            //Service.LoggedUser = user[0];
            UpdateCartStr();
            Service.MainViewModel = this;
            UpdatePage(Service.catalogPage);

            SetVisibility(true);


        }


        public void SetVisibility(bool _switch)
        {
            if (_switch == false)
            {
                AuthVis = Visibility.Hidden;
                NameVis = Visibility.Visible;
                _user = Service.LoggedUser;

            }
            else if (_switch == true)
            {
                NameVis = Visibility.Hidden;
                AuthVis = Visibility.Visible;
            }
            OnPropertyChanged("AuthVis");
            OnPropertyChanged("NameVis");
            OnPropertyChanged("User");

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
