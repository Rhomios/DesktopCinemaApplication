﻿using MyMoviesWPF.MVVM.ViewModel;
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
using System.Windows.Shapes;

namespace MyMoviesWPF.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для MovieView.xaml
    /// </summary>
    public partial class MovieView : Window
    {
        public MovieView()
        {
            InitializeComponent();
            DataContext = new MovieViewModel();
        }
    }
}