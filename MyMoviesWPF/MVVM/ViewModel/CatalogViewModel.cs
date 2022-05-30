using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoviesWPF.MVVM.ViewModel
{
    public class CatalogViewModel : BaseViewModel
    {
        private BaseViewModel _toolbar = new UserViewModel();
        private BaseViewModel _view = new UserViewModel();


        public BaseViewModel CurrentToolbar
        {
            get { return _toolbar; }
            set
            {
                _toolbar = value;
                OnPropertyChanged();
            }
        }
        public BaseViewModel CurrentControlView
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
