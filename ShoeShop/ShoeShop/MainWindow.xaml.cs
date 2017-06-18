﻿using System;
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

namespace ShoeShop
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PageH();
        }

        public void PageM()
        {
            _mainFrame.Navigate(new MenPage());
        }
        public void PageH()
        {
            _mainFrame.Navigate(new Homepage());
        }
        public void PageW()
        {
            _mainFrame.Navigate(new WomenPage());
        }
        public void PageC()
        {
            _mainFrame.Navigate(new ContactPage());
        }
    }
}