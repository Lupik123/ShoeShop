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
    /// Interakční logika pro Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        User user;
        int index;

        public Registration()
        {
            InitializeComponent();

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



        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                user = list.SelectedItem as User;
                index = list.SelectedIndex;

                fName.Text = user.Name;
                email.Text = user.Email;
                birth.Text = user.BirthDate;

                add.IsEnabled = false;
                edit.IsEnabled = true;
                delete.IsEnabled = true;

            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddUser();
            ShowData();
            ClearBox();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser();
            ClearBox();
            ShowData();

            add.IsEnabled = true;
            edit.IsEnabled = false;
            delete.IsEnabled = false;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            EditUser();
            ClearBox();
            ShowData();

            add.IsEnabled = true;
            edit.IsEnabled = false;
            delete.IsEnabled = false;
        }


        private void AddUser()
        {
            //Kontroluje zda jsou zadany všechny hodnoty
            if (fName.Text != null && lName.Text != null && email.Text != null && birth.Text != null)
            {
                if (fName.Text != "" && lName.Text != "" && email.Text != "" && birth.Text != "")
                {
                    user = new User();
                    user.Name = fName.Text + " " + lName.Text;
                    user.BirthDate = birth.Text;
                    user.Email = email.Text;


                    Database.SaveItemAsync(user);
                    result.Text = "User was added.";
                }
                else
                {
                    result.Text = "Fill all boxes.";
                }
            }
        }

        private void DeleteUser()
        {
            user = (User)list.SelectedItems[0];
            Database.DeleteItemAsync(user);
        }

        private void EditUser()
        {
            list.SelectedIndex = index;
            user = list.SelectedItem as User;

            if (fName.Text != null && lName.Text != null && email.Text != null && birth.Text != null)
            {
                if (fName.Text != "" && lName.Text != "" && email.Text != "" && birth.Text != "")
                {
                    list.SelectedIndex = index;
                    user.Name = fName.Text + " " + lName.Text;
                    user.BirthDate = birth.Text;
                    user.Email = email.Text;


                    Database.SaveItemAsync(user);
                    result.Text = "User was added.";
                }
                else
                {
                    result.Text = "Fill all boxes.";
                }
            }
        }


        private void ClearBox()
        {
            fName.Text = "";
            lName.Text = "";
            email.Text = "";
            birth.Text = "";
        }

        private void ShowData()
        {
            List<User> items = new List<User>();

            var itemsFromDb = Database.GetItemsAsync().Result;
            foreach (User user in itemsFromDb)
            {
                items.Add(new User() { ID = user.ID, Name = user.Name, Email = user.Email, BirthDate = user.BirthDate });
            }

            list.ItemsSource = items;
        }


        private void home_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Content = new Homepage();
        }

       
    }
}
