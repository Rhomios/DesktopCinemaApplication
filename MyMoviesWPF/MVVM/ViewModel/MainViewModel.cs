using Microsoft.Toolkit.Mvvm.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace MyMoviesWPF.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        //UserViewModel _userViewModel = new UserViewModel();
        
        private BaseViewModel _toolbar = new UserViewModel();
        private BaseViewModel _view    = new CatalogViewModel();


        public BaseViewModel CurrentToolbar
        {
            get { return _toolbar; }
            set
            {
                _toolbar = value;
                OnPropertyChanged();
            }
        }
        public BaseViewModel CurrentView
        {
            get { return _view; }
            set
            {
                _view = value;
                OnPropertyChanged();
            }
        }


    }
}
