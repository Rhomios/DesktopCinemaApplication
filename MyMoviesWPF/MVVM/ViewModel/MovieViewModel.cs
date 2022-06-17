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
        private ObservableCollection<ActorList> _actors;
        public string Name { get => Service.movie.Name; }
        public string Description { get => Service.movie.Description; }
        public Genre Genre { get => Service.db.Genres.Where(g => g.Idgenre == Service.movie.Idgenre).FirstOrDefault(); }
        public string TrailerURL { get => Service.movie.Trailer; }
        public string Year { get => Convert.ToString(Service.movie.ProductYear); }
        public string Languages { get => Service.movie.Languages; }
        public string Price { get => Convert.ToString(Service.movie.Price); }

        public ObservableCollection<ActorList> ActorsCollection
        {
            get => _actors;
            set
            {
                _actors = value;
            }
        }
        public MovieViewModel()
        {
            ActorsCollection = new(Service.db.ActorLists.Where(o => o.ListNum == Service.movie.IdactorList).Include(q => q.IdactorNavigation));
        }


    }
}
