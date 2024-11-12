using AOA.Connection;
using AOA.Connection.Entities;
using AOA.LocalData;
using AOA.Pages.EventsPages;
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
    /// Interaction logic for EventInfoPage.xaml
    /// </summary>
    public partial class EventInfoPage : Page
    {
        Offer _offer;
        public EventInfoPage(Offer offer)
        {
            InitializeComponent();
            _offer = offer;
            DataContext = offer;
            if(offer.AuthorId == AuthUser.User.Id)
            {
                btnDelete.Visibility = Visibility.Visible;
                bntChange.Visibility = Visibility.Visible;
            }
        }

        private void btnCheckUserclick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserInfoPage(_offer.Author));
        }

        private void btnBackCLick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnChangeClick(object sender, RoutedEventArgs e)
        {
            int i;
            if (_offer.TypeEvent == Offer.EType.Zakaz)
            {
                i = 1;
            }
            else
                i = 2;
           new EventAddWindow(_offer, i).ShowDialog();
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите удалить объявление", "Уведомление!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                EfModel.Init().Offers.Remove(_offer);
                EfModel.Init().SaveChanges();
            }
        }
    }
}
