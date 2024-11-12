using AOA.Connection;
using AOA.Connection.Entities;
using AOA.LocalData;
using AOA.Pages.CompamyPage;
using AOA.Pages.PagesAuth;
using AOA.Windows;
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

namespace AOA.Pages.PagesNavigation
{
    /// <summary>
    /// Interaction logic for UserInfoPage.xaml
    /// </summary>
    public partial class UserInfoPage : Page
    {
        public static bool Userfo = true;
        User user;
        public UserInfoPage(User u)
        {
            InitializeComponent();
            user = u;
            if(u== null)
            DataContext = AuthUser.User;
            else
                DataContext = u;
            if (user != AuthUser.User)
            {
                btnChange.Visibility = Visibility.Hidden;
                BtnLogOut.Visibility = Visibility.Hidden;
                bntDelete.Visibility = Visibility.Hidden;
            }
        }
        private void btnDeleteUser(object sender, RoutedEventArgs e)
        {
            
            if (MessageBox.Show("Вы действительно хотите удалить свой профиль?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                new PaswwordAddPage().ShowDialog();
                if(Userfo)
                {

                }
                else
                {
                    NavigationService.Navigate(new NewsPage());
                    MainWindow.RightSide.Navigate(new FrontPage());
                    MessageBox.Show("Завершено.");
                }
               
            }
            else
            {

            }
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnLogOutClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из аккаунта?", "Предупреждение", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                AuthUser.User = null;
                NavigationService.Navigate(new NewsPage());
                MainWindow.RightSide.Navigate(new FrontPage());
            }
        }

        private void btnCompanyClick(object sender, RoutedEventArgs e)
        {
            Company company = EfModel.Init().Companies.Where(c=> c.Id == user.Companyid).FirstOrDefault();
            NavigationService.Navigate(new CompanyInfoPage(company));
        }

        private void btnChangeClick(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow(null).ShowDialog();
            AuthUser.User = EfModel.Init().Users.Where(user => user.Id == AuthUser.User.Id).FirstOrDefault();
            DataContext = AuthUser.User;
        }
    }
}
    
