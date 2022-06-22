using Core.RelayCommand;
using MyMoviesWPF.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyMoviesWPF.MVVM.ViewModel
{
    internal class LogInViewModel
    {
        public string EnteredLogin { get; set; }
        private RelayCommand _signIn;
        public LogInViewModel()
        {

        }

        //public RelayCommand SignIn
        //{
        //    get
        //    {
        //        return _signIn
        //          ?? (_signIn = new RelayCommand(
        //            async () =>
        //            {
        //                
        //            }));
        //    }
        //}



        public RelayCommand SignIn
        {
            get => new RelayCommand(o =>
            {
                PasswordBox password = o as PasswordBox;

                var user = Service.db.Users.FirstOrDefault(u => u.Login == EnteredLogin && u.Password == password.Password);

                if (user != null)
                {
                    Service.LoggedUser = user;

                    Service.MainViewModel.SetVisibility(false);

                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item.DataContext == this) item.Close();
                    }


                }
                else
                {
                    MessageBox.Show("Введены неверные данные или пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            });

        }
    }
}

