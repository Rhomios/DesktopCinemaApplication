using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMoviesWPF.MVVM.View;

namespace MyMoviesWPF.MVVM.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public RelayCommand<object> OpenMainSR
        {
            get => new RelayCommand<object>(o =>
            {
               MainSR sr = new MainSR();
               sr.Show();

            }
            );
        }

        //foreach (Window item in Application.Current.Windows)
        //    {
        //        if (item.DataContext == this) item.Close();
        //    }
        //public RelayCommand LogInCommand
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
