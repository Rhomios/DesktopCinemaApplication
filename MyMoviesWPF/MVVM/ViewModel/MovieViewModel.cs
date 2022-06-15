using Microsoft.EntityFrameworkCore;
using MyMoviesWPF.Models;
using MyMoviesWPF.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoviesWPF.MVVM.ViewModel
{
    public class MovieViewModel : BaseViewModel
    {
        public string Name { get => Service.movie.Name; }
        public string Description { get => Service.movie.Description;}
        public string Category { get => Service.movie.; }

        public MovieViewModel()
        {
            OnPropertyChanged("Name");
        }


    }
}
