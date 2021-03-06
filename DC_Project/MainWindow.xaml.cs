﻿using DC_Project.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DC_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Links the Databinding Context to the ViewModel
            this.DataContext = new MainWindowViewModel(this);
        }

        private void gridz_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Makes custom window draggable
            this.DragMove();
        }
    }
}
