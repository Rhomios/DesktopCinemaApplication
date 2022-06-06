using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MyMoviesWPF.MVVM.ViewModel.Core;
using MyMoviesWPF.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;
using MyMoviesWPF.MVVM.View;

namespace MyMoviesWPF.MVVM.ViewModel
{
    public class CatalogViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> MoviesCollection { get; set; }
        private BaseViewModel _toolbar = new UserViewModel();
        private BaseViewModel _view = new UserViewModel();
        private Movie _movie;



        public CatalogViewModel()
        {
            MoviesCollection = new ObservableCollection<Movie>(Service.db.Movies.ToList());
        }

 
        public Movie OpenMovieWindow
        {
            get
            {
                return _movie;

            }
            set
            {
                _movie = value;
                Service.movie = _movie;
                _movie = null;
                foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this) item.Hide();
                }
                MovieView movieView = new MovieView();
                movieView.Show();
            }

        }



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
