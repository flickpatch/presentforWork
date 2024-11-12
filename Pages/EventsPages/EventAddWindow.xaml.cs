using AOA.Actions;
using AOA.Connection;
using AOA.Connection.Entities;
using AOA.LocalData;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace AOA.Pages.EventsPages
{
    /// <summary>
    /// Interaction logic for EventAddWindow.xaml
    /// </summary>
    public partial class EventAddWindow : Window
    {
        Offer offer;
        private int NumberEvent;
        public EventAddWindow(Offer off , int EventNumber)
        {
            InitializeComponent();
            NumberEvent = EventNumber;
            offer = off;
            if(off.Id != 0)
            {
                btnAdd.Content = "Изменить";
            }
            DataContext = offer;
            cbCotagories.ItemsSource = EfModel.Init().OfferTypes.ToList();
        }

        private void btnAddPhotoclick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.jfif";
            if(dialog.ShowDialog() == true)
            {
                offer.Photo = File.ReadAllBytes(dialog.FileName);
                imgPhoto.Source = ImageConverter.ConvertPhoto(offer.Photo);
            }
        }

        private void btnGoClick(object sender, RoutedEventArgs e)
        {
            offer = DataContext as Offer;
            offer.CategoryID = (cbCotagories.SelectedItem as OfferType).Id; 
            if(NumberEvent == 1)
            {
                offer.TypeEvent = Offer.EType.Zakaz;
            }
            else
            {
                offer.TypeEvent = Offer.EType.Offer;
            }
            if(offer.Id != 0)
            {
                EfModel.Init().Offers.Update(offer);
            }
            else
            {
                offer.AuthorId = AuthUser.User.Id;
                offer.Author = AuthUser.User;
                EfModel.Init().Offers.Add(offer);
                MessageBox.Show("Успешно.");
                
            }
            EfModel.Init().SaveChanges();
            Close();
        }
    }
}
