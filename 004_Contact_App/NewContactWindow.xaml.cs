using _004_Contact_App.Classes;
using SQLite;
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


namespace _004_Contact_App
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //save contact 
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text, 
                Phone = phoneTextBox.Text
            };

            string dataBaseName = "Contact.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   
            string dataBasePath = System.IO.Path.Combine(folderPath, dataBaseName);

            SQLiteConnection connection = new SQLiteConnection(dataBasePath);
            connection.CreateTable<Contact>();
            connection.Insert(contact);
            connection.Close();

            this.Close();
        }
    }
}
