using AOA.Connection;
using AOA.LocalData;
using AOA.Pages.PagesNavigation;
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

namespace AOA.Windows
{
    /// <summary>
    /// Interaction logic for PaswwordAddPage.xaml
    /// </summary>
    public partial class PaswwordAddPage : Window
    {
        public PaswwordAddPage()
        {
            InitializeComponent();
        }

        private void btnYesClick(object sender, RoutedEventArgs e)
        {
            if (PbPass.Password == AuthUser.User.Pass)
            {
                try
                {
                    EfModel.Init().Users.Remove(AuthUser.User);
                    EfModel.Init().SaveChanges();
                    MessageBox.Show("Ваш пользователь удален");
                    UserInfoPage.Userfo = false;
                    Close();
                }
                catch
                {
                    MessageBox.Show("error");
                }
            }
            else
            {
                MessageBox.Show("Не верный пароль.");
            }
           
        }
    }
}
