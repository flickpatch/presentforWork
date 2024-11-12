using AOA.Connection;
using AOA.Connection.Entities;
using AOA.LocalData;
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

namespace AOA.Windows
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void cbVisibleCheck(object sender, RoutedEventArgs e)
        {
            pbPass.Visibility = Visibility.Hidden;
            tblPass.Visibility = Visibility.Visible;
                tblPass.Text = pbPass.Password.ToString();
    
        }

        private void cbVisibleUnCheck(object sender, RoutedEventArgs e)
        {
            tblPass.Visibility = Visibility.Hidden;
            pbPass.Visibility = Visibility.Visible;
            pbPass.Password = tblPass.Text;
        }

        private void btnRegClick(object sender, RoutedEventArgs e)
        {
            Close();
            new RegistrationWindow(new User()).ShowDialog();
        }

        private void bntAuthClick(object sender, RoutedEventArgs e)
        {
            User u = EfModel.Init().Users.Where(u => u.Login == tbLogin.Text && u.Pass == pbPass.Password).FirstOrDefault();
            if (u != null)
            {
                AuthUser.User = u; 
                Close();
            }
            else
                MessageBox.Show("Не верное имя пользователя или пароль.");
        }
    }
}
