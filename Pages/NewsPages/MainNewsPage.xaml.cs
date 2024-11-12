using AOA.Connection;
using AOA.Connection.Entities;
using AOA.LocalData;
using AOA.Pages.NewsPages;
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

namespace AOA.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewsPage.xaml
    /// </summary>
    public partial class MainNewsPage : Page
    {
        public MainNewsPage()
        {
            
            InitializeComponent();         
            
            UserCheck();
            UpdateNews();
        }
        private void UserCheck()
        {
            if (AuthUser.User != null)
            {
                if (AuthUser.User.Role == User.Roles.Admin)
                {
                    btnAdd.Visibility = Visibility.Visible;
                    btnDelete.Visibility = Visibility.Visible;
                    btnChange.Visibility = Visibility.Visible;

                }
                else
                {

                    btnAdd.Visibility = Visibility.Hidden;
                    btnDelete.Visibility = Visibility.Hidden;
                    btnChange.Visibility = Visibility.Hidden;
                }

            }
        }
        private  void UpdateNews()
        {
            var i = EfModel.Init().News.ToList();
            lvNews.ItemsSource = i;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ClickListView(object sender, MouseButtonEventArgs e)
        {
           News news = new News();
            news = lvNews.SelectedItem as News;
            if(news !=null)
            {
                NavigationService.Navigate(new NewInfoPage(news));
            }
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddNewNewPAge(new News()));
            UpdateNews();
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            if (lvNews.SelectedItem != null)
            {
                News news = lvNews.SelectedItem as News;
                EfModel.Init().News.Remove(news);
                EfModel.Init().SaveChanges();
                UpdateNews();
            }
            else
                MessageBox.Show("Выберите новость");

        }

        private void btnChangeCLick(object sender, RoutedEventArgs e)
        {
            News New= lvNews.SelectedItem as News;
            if (New != null)
            {
                NavigationService.Navigate(new AddNewNewPAge(New));
                UpdateNews();
            }
            else
                MessageBox.Show("Выберите новость.");
        }

        private void btnUpdateClick(object sender, RoutedEventArgs e)
        {
            UpdateNews();
        }
    }
}
