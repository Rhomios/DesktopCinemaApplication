using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MyMoviesWPF.MVVM.ViewModel;

namespace MyMoviesWPF.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для MainSR.xaml
    /// </summary>
    public partial class MainSR : Window
    {
        public MainSR()
        {
            InitializeComponent();
            DataContext = new MainSRViewModel();
        }
    }
}
