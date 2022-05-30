using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMoviesWPF.MVVM.View;
using MyMoviesWPF.MVVM.View.UserInit;


namespace MyMoviesWPF.MVVM.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public RelayCommand<object> OpenLogInWindow
        {
            get => new RelayCommand<object>(o =>
            {
                LogInView view = new LogInView();
                view.Show();

            }
            );
        }

        public RelayCommand<object> OpenSignUpWindow
        {
            get => new RelayCommand<object>(o =>
            {
                LogInView view = new LogInView();
                view.Show();

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
