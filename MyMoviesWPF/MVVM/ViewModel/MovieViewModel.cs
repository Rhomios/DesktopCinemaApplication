using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.Input;
using MyMoviesWPF.Models;
using MyMoviesWPF.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyMoviesWPF.MVVM.ViewModel
{
    public class MovieViewModel : BaseViewModel
    {
        private ObservableCollection<ActorList> _actors;
        private RelayCommand _addToCart;
        private RelayCommand _cancel;
        private bool _addToCartEnability = true;
        private Order _orders;
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

        public RelayCommand Cancel
        {
            get
            {
                return _cancel
                  ?? (_cancel = new RelayCommand(
                    async () =>
                    {
                        Service.MainViewModel.UpdatePage(Service.catalogPage);
                    }));
            }
        }



        public MovieViewModel()
        {
            ActorsCollection = new(Service.db.ActorLists.Where(o => o.ListNum == Service.movie.IdactorList).Include(q => q.IdactorNavigation));
            foreach(Order order in Service.db.Orders)
            {
                if(order.Idmovie == Service.movie.Idmovie && order.Iduser == Service.LoggedUser.Iduser && order.Status != "Отменен")
                {
                    UpdateEnability(false);
                }
            }
            

        }

        public Order Orders
        {
            get => _orders;
            set
            {
                if (_orders == value)
                    return;

                _orders = value;
                OnPropertyChanged("Orders");

            }
        }

        public bool AddToCartEnability
        {
            get => _addToCartEnability;
            set
            {
                if (_addToCartEnability == value)
                    return;

                _addToCartEnability = value;
                OnPropertyChanged("AddToCartEnability");
            }
        }

        public RelayCommand AddToCart
        {
            get
            {
                return _addToCart
                  ?? (_addToCart = new RelayCommand(
                    async () =>
                    {
                        MessageBox.Show("Фильм успешно добавлен в корзину !", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);               
                        Service.CartMoviesCollection.Add(Service.movie);
                        Service.MainViewModel.UpdateCartStr();
                        UpdateEnability();

                    }));
            }
        }

        public void UpdateEnability()
        {
            if(_addToCartEnability == true)
            {
                _addToCartEnability = false;
            }
            else
            {
                _addToCartEnability = true;
            }
            OnPropertyChanged("AddToCartEnability");
        }

        public void UpdateEnability(bool value)
        {
            _addToCartEnability = value;
     
            OnPropertyChanged("AddToCartEnability");
        }


    }
}
