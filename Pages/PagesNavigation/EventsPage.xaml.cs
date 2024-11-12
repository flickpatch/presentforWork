using AOA.Connection;
using AOA.Connection.Entities;
using AOA.Pages.EventsPages;
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
using static AOA.Connection.Entities.Offer;

namespace AOA.Pages.PagesNavigation
{
    /// <summary>
    /// Interaction logic for EventsPage.xaml
    /// </summary>
    public partial class EventsPage : Page
    {
        public int EventNumber = 0;
        public EventsPage(string EventName, int EventNum)
        {
            InitializeComponent();
            EventNumber = EventNum;
            tblEventName.Text = EventName;
            cbCategory.ItemsSource = EfModel.Init().OfferTypes.ToList();
            cbCategory.SelectedIndex =8;            
            Update();
        }
        private void Update()
        {
            List<Offer> Offers = new List<Offer>();
            if (EventNumber == 1)
            {
                Offers = EfModel.Init().Offers.Where(offer => offer.TypeEvent == EType.Zakaz).Include(o=> o.Author).ThenInclude(a=> a.Company).ToList();
            }
            else if (EventNumber == 2)
            {
                Offers = EfModel.Init().Offers.Where(offer => offer.TypeEvent == EType.Offer).ToList();
            }
            if (tbSearch.Text != "")
       
            {
                
                if((cbCategory.SelectedItem as OfferType).Id != 9)
                {
                   lvEvents.ItemsSource = Offers.Where(o => o.Name.Contains(tbSearch.Text) && o.CategoryID == (cbCategory.SelectedItem as OfferType).Id);
                }
                else
                {
                    lvEvents.ItemsSource = Offers.Where(o => o.Name.Contains(tbSearch.Text));
                }
            }
            else
            {
                if((cbCategory.SelectedItem as OfferType).Id != 9)
                {
                    lvEvents.ItemsSource = Offers.Where(o=> o.CategoryID == (cbCategory.SelectedItem as OfferType).Id);

                }
                else
                {
                    lvEvents.ItemsSource = Offers;
                }
                
            }
                
           
        }
        private void tbSearchChange(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            new EventAddWindow(new Offer(), EventNumber).ShowDialog();
            Update();
        }

        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            if(lvEvents.SelectedItems!=null)
            {
                Offer off = lvEvents.SelectedItem as Offer;
                new EventAddWindow(off, EventNumber).ShowDialog();
                Update();
            }

            else
            {
                MessageBox.Show("Выберите объявление.");
            }

        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (lvEvents.SelectedItems != null)
                new EventAddWindow(new Connection.Entities.Offer(), EventNumber).ShowDialog();
            else
            {
                MessageBox.Show("Выберите объявление.");
            }

        }
        private void ChangeCb(object sender, SelectionChangedEventArgs e)
        {
            Update();

        }

        private void selectAndCheckUser(object sender, MouseButtonEventArgs e)
        {
            Offer off = lvEvents.SelectedItem as Offer;
            if (off != null)
            {
                NavigationService.Navigate(new EventInfoPage(off));
            }
            
        }

        private void btnBackCLick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
