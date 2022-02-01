using _004_Contact_App.Classes;
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

namespace _004_Contact_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDataBase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
//            newContactWindow.Show();
            newContactWindow.ShowDialog();
            ReadDataBase();

        }

        void ReadDataBase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dataBasePath)) 
            {
                conn.CreateTable<Contact>();
                contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
            }

            if (contacts != null) 
            {
                contactsListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTexBox = sender as TextBox;
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTexBox.Text.ToLower())).ToList();
            contactsListView.ItemsSource = filteredList;
        }
    }
}
