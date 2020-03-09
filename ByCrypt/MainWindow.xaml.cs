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
using BCrypt.Net;
using ByCrypt.Classes;

namespace ByCrypt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = new Database();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            db.AddUser(Username.Text, CreateHashFromString(Password.Text));
            MessageBox.Show("Gebruiker toegevoegd");
        }

        private string CreateHashFromString(string strPwd)
        {
            strPwd = strPwd + "$Y.N3T-J*-3";

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string strHashed = BCrypt.Net.BCrypt.HashPassword(strPwd, salt);

            return strHashed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }
    }
}
