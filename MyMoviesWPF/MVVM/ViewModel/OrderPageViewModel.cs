using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.Input;
using MyMoviesWPF.MVVM.View.Pages;
using MyMoviesWPF.MVVM.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyMoviesWPF.MVVM.ViewModel
{
    internal class OrderPageViewModel : BaseViewModel
    {
        private ObservableCollection<Order> _orders;
        private RelayCommand _continuePayment;
        private RelayCommand _cancel;
        private Order _selectedOrder;
        private string _sum;
        private string _amount;
        private string _selectedPayment;
        private bool _continuePaymentEnability = true;

        //    A.Where(x => Char.IsDigit(x[0]) && x.Length == L).ToList().LastOrDefault() ?? "Not found";
        //A.Sum(x => x.Length));  


        public bool ContinuePaymentEnability
        {
            get => _continuePaymentEnability;
            set
            {
                if (_continuePaymentEnability == value)
                    return;

                _continuePaymentEnability = value;
                OnPropertyChanged("ContinuePaymentEnability");
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
                        foreach (Order order in Orders)
                        {
                            order.Status = "Отменен";

                            Service.db.Orders.Update(order);
                            Service.db.SaveChanges();
                        }
                        Service.CartMoviesCollection.Clear();
                        Orders.Clear();
                        Service.MainViewModel.UpdateCartStr();
                        Service.MainViewModel.UpdatePage(Service.catalogPage);

                    }));
            }
        }



        private ObservableCollection<String> _payments = new ObservableCollection<String>() { "Sberbank", "Paypal", "Gazprombank", "RosSelkhozbank" };

        public ObservableCollection<String> Payments
        {
            get => _payments;
            set
            {
                if (_payments == value)
                    return;

                _payments = value;
                OnPropertyChanged("Payments");
            }
        }

        public string SelectedPayment
        {
            get => _selectedPayment;
            set
            {
                if (_selectedPayment == value)
                    return;

                _selectedPayment = value;
                if (_continuePaymentEnability == false && Orders != null)
                {
                    if(Orders.Count == 1 && Orders[0] != null || Orders.Count > 1)
                    {
                        UpdateEnability(true);
                    }
                }
                OnPropertyChanged("SelectedPayment");
            }
        }
        public string Sum
        {
            get => _sum;
            set
            {
                if (_sum == value)
                    return;

                _sum = value;
                OnPropertyChanged("Sum");
            }
        }


        public string Amount
        {
            get => _amount;
            set
            {
                if (_amount == value)
                    return;

                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                if (_orders == value)
                    return;

                _orders = value;
                OnPropertyChanged("Orders");
            }
        }
        //SelectedOrder

        public Order SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ContinuePayment
        {
            get
            {
                return _continuePayment
                  ?? (_continuePayment = new RelayCommand(
                    async () =>
                    {
                        Payment payment = new Payment();
                        payment.PaymentType = SelectedPayment;
                        payment.Sum = Decimal.Parse(Sum);
                        payment.Date = DateTime.Now;
                        payment.Status = "Успешно";
                        Service.db.Payments.Add(payment);
                        Service.db.SaveChanges();

                        foreach (Order order in Orders)
                        {
                            order.Status = "Выполнен";
                            order.IdpaymentNavigation = payment;

                            Service.db.Orders.Update(order);
                            Service.db.SaveChanges();
                        }
                        Service.CartMoviesCollection.Clear();
                        Orders.Clear();
                        Service.MainViewModel.UpdateCartStr();
                        MessageBox.Show("Операция прошла успешно !", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        Service.MainViewModel.UpdatePage(Service.catalogPage);


                    }));
            }
        }

        public OrderPageViewModel()
        {
            foreach (Movie thing in Service.CartMoviesCollection)
            {
                Order order = new Order();
                order.Idmovie = thing.Idmovie;
                order.Iduser = Service.LoggedUser.Iduser;
                order.Status = "В Процессе";
                order.Price = thing.Price;
                order.Date = DateTime.Now;

                //Orders.Add(order);
                
                Service.db.Orders.Add(order);
                Service.db.SaveChanges();
            }
            _orders = new ObservableCollection<Order>(Service.db.Orders.Where(x => x.Status == "В Процессе"));
            Orders = new(Service.db.Orders.Where(o => o.Status == "В Процессе").DefaultIfEmpty().Include(q => q.IdmovieNavigation).Include(u => u.IduserNavigation));

            OnPropertyChanged("Orders");
            _sum = Convert.ToString((from x in Orders where x != null select x.Price).DefaultIfEmpty().Sum() ?? 0 );
            OnPropertyChanged("Sum");
            _amount = Convert.ToString((from x in Orders where x != null select x.Idorder).DefaultIfEmpty().Count());


            if(Orders != null)
            {
                UpdateEnability(true);
            }
            if(SelectedPayment == null)
            {
                UpdateEnability(false);
            }


        }




        public void UpdateEnability()
        {
            if (_continuePaymentEnability == true)
            {
                _continuePaymentEnability = false;
            }
            else
            {
                _continuePaymentEnability = true;
            }
            OnPropertyChanged("ContinuePaymentEnability");
        }

        public void UpdateEnability(bool value)
        {
            _continuePaymentEnability = value;

            OnPropertyChanged("ContinuePaymentEnability");
        }

    }
}
