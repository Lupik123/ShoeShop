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
    /// Interakční logika pro Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void men_Click(object sender, RoutedEventArgs e)
        {
            //_mainFrame.Navigate(new MenPage());
        }

        private void women_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contact_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
