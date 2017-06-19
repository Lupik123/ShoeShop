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

namespace ShoeShop
{
    /// <summary>
    /// Interakční logika pro WomenPage.xaml
    /// </summary>
    public partial class WomenPage : Page
    {
        public WomenPage()
        {
            InitializeComponent();
        }

        private void men_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Content = new MenPage();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Content = new Homepage();
        }

        private void contact_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Content = new ContactPage();
        }

        private void addU_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Content = new Registration();
        }
    }
}
