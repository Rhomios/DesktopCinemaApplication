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


        public MainViewModel()
        {
            Service.MainViewModel = this;
            _currentPage = new CatalogPage();

        }



        public void UpdatePage(Page _page)
        {
            _currentPage = _page;
            OnPropertyChanged("CurrentPage");
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
