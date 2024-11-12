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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AOA.Pages.PagesAuth
{
    /// <summary>
    /// Логика взаимодействия для DataUserPage.xaml
    /// </summary>
    public partial class DataUserPage : Page
    {
        public DataUserPage()
        {
            InitializeComponent();
            DataContext = AuthUser.User;
        }

        private void btnInfoClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Auth.Navigate(new UserInfoPage(AuthUser.User)) ;    
        }

        private void ClickName(object sender, MouseButtonEventArgs e)
        {          
            MainWindow.Auth.Navigate(new UserInfoPage(AuthUser.User));
        }

        private void Zakazclick(object sender, RoutedEventArgs e)
        {
            MainWindow.Auth.Navigate(new EventsPage("Заказы", 1));
        }

        private void EventsClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Auth.Navigate(new EventsPage("Объявления", 2));
        }
    }
}
