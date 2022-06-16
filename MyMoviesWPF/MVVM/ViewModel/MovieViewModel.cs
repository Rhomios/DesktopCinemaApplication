using Microsoft.EntityFrameworkCore;
using MyMoviesWPF.Models;
using MyMoviesWPF.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoviesWPF.MVVM.ViewModel
{
    public class MovieViewModel : BaseViewModel
    {
        public string Name { get => Service.movie.Name; }
        public string Description { get => Service.movie.Description;}
        public Genre Genre { get => Service.db.Genres.Where(g => g.Idgenre == Service.movie.Idgenre).FirstOrDefault(); }
        //public string Category { get => Service.movie.; }
        public string TrailerURL { get => Service.movie.Trailer; }
        public string Year { get => Convert.ToString(Service.movie.ProductYear); }
        public string Languages { get => Service.movie.Languages; }
        public string Price { get => Convert.ToString(Service.movie.Price); }
        //public ObservableCollection<Actor> ActorsCollection
        //{
        //    //get => Service.db.ActorLists.Where(a => a.ListNum == Service.movie.IdactorList)

        //}

        public MovieViewModel()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("TrailerURL");
        }


    }
}
