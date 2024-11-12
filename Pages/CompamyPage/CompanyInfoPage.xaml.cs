using AOA.Connection;
using AOA.Connection.Entities;
using AOA.Pages.PagesNavigation;
using Microsoft.EntityFrameworkCore;
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

namespace AOA.Pages.CompamyPage
{
    /// <summary>
    /// Interaction logic for CompanyInfoPage.xaml
    /// </summary>
    public partial class CompanyInfoPage : Page
    {
        Company _company;
        public CompanyInfoPage(Company company)
        {
            InitializeComponent();
            _company = EfModel.Init().Companies.Where(c => c.Id == company.Id).FirstOrDefault(); ;
            DataContext = _company;
        }

        private void btnCheckUserClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserInfoPage(_company.Users.Where(u=> u.Id == 1).FirstOrDefault()));
        }

        private void btnBackLCick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
