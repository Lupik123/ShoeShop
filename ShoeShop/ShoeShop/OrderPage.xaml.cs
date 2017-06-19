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
    /// Interakční logika pro OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        Shoes shoes = new Shoes();
        Order order;
        User user;
        int index;
        int imp;

        public OrderPage(int shoeId)
        {
            InitializeComponent();

            imp = shoeId;


            ShowData();
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

        private static OrderDatabase _ord;

        public static OrderDatabase ORD
        {
            get
            {
                if (_ord == null)
                {
                    var fileHelper = new FileHelper();
                    _ord = new OrderDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _ord;
            }
        }


        private void ShowData()
        {
            List<User> items = new List<User>();

            var itemsFromDb = Database.GetItemsAsync().Result;
            foreach (User user in itemsFromDb)
            {
                items.Add(new User() { ID = user.ID, Name = user.Name});
            }

            cmb.ItemsSource = items;

            List<Order> items2 = new List<Order>();

            var itemsFromDb2 = ORD.GetItemsAsync().Result;
            foreach (Order order in itemsFromDb2)
            {
                items2.Add(new Order() { ID = order.ID, UserID = order.UserID, ShoesID = order.ShoesID });
            }

            list.ItemsSource = items2;
        }



        private void home_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Content = new Homepage();
        }

        private void addU_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Content = new Registration();
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            list.SelectedIndex = index;
            user = list.SelectedItem as User;

            order = new Order();
            order.ShoesID = imp;
            order.UserID = user.ID;



            ORD.SaveItemAsync(order);

        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                user = list.SelectedItem as User;
                index = list.SelectedIndex;

            }
        }
    }
}
