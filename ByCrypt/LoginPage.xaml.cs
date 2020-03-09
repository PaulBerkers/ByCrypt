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
using BCrypt.Net;
using ByCrypt.Classes;

namespace ByCrypt
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        Database db = new Database();
        bool login = false;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login = VerifyUser(LoginUsername.Text, LoginPassword.Text);
            if (login ==  true)
            {
                MessageBox.Show("Gebruiker is ingelogd");
            }
            else
            {
                MessageBox.Show("Inloggen niet gelukt");
            }
        }

        private bool VerifyUser(string UserName, string strPwd)
        {
            strPwd = strPwd + "$Y.N3T-J*-3";

            string strHashed = db.GetPassword(UserName);

            return BCrypt.Net.BCrypt.Verify(strPwd, strHashed);
        }
    }
}