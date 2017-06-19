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
        Shoes shoes;
        int index;
        Random rnd = new Random();

        public Homepage()
        {
            InitializeComponent();

            ShowData();
            /*for(int i = 1; i < 10; i++)
            {
                int price = rnd.Next(1200, 2500);
                int size = rnd.Next(40, 47);
                shoes = new Shoes();
                shoes.Name = "Shoes" + i;
                shoes.Brand = "Nike";
                shoes.Category = "Men";
                shoes.Size = size;
                shoes.Price = price;

                //SH.SaveItemAsync(shoes);
            }*/

            //text.Text = SH.GetItemsAsync().Result.Count.ToString();



        }

        private static UserDatabase _database;

        public static UserDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new FileHelper();
                    _database = new UserDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }

        private static ShoesDatabase _sh;

        public static ShoesDatabase SH
        {
            get
            {
                if (_sh == null)
                {
                    var fileHelper = new FileHelper();
                    _sh = new ShoesDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _sh;
            }
        }

        private void ShowData()
        {
            List<Shoes> items = new List<Shoes>();

            var itemsFromDb = SH.GetItemsCategory("Men").Result;
            foreach (Shoes shoes in itemsFromDb)
            {
                items.Add(new Shoes() { Name = shoes.Name, Brand = shoes.Brand, Size = shoes.Size, Price = shoes.Price });
            }

            listMen.ItemsSource = items;

            List<Shoes> items2 = new List<Shoes>();

            var itemsFromDb2 = SH.GetItemsCategory("Women").Result;
            foreach (Shoes shoes in itemsFromDb2)
            {
                items2.Add(new Shoes() { Name = shoes.Name, Brand = shoes.Brand, Size = shoes.Size, Price = shoes.Price });
            }

            listWomen.ItemsSource = items2;


        }










        //navigace

        private void addU_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Content = new Registration();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listMen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listMen.SelectedItem != null)
            {
                shoes = listMen.SelectedItem as Shoes;
                index = listMen.SelectedIndex;

                cart.IsEnabled = true;
            }
        }

        private void listWomen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listWomen.SelectedItem != null)
            {
                shoes = listWomen.SelectedItem as Shoes;
                index = listWomen.SelectedIndex;

                cart.IsEnabled = true;
            }
        }

        private void cart_Click(object sender, RoutedEventArgs e)
        {
            listMen.SelectedIndex = index;
            shoes = listMen.SelectedItem as Shoes;

            App.Current.MainWindow.Content = new OrderPage(shoes.ID);
        }
    }
}
