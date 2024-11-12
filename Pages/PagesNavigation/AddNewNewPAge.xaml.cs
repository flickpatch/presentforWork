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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AOA.Pages.PagesNavigation
{
    /// <summary>
    /// Логика взаимодействия для AddNewNewPAge.xaml
    /// </summary>
    public partial class AddNewNewPAge : Page
    {
        News New;
        
        public AddNewNewPAge(News news)
        {
            InitializeComponent();
            New = news;
            DataContext= New;
            if (news.Id != 0)
                btnAdd.Content = "Изменить новость";
        }

        private void btnAddNewClick(object sender, RoutedEventArgs e)
        {
            New = DataContext as News;
            if(New.Id == 0)
            {
                New.Content = tbContent.Text;
                New.Title = tbTitle.Text;
                New.UserId = AuthUser.User.Id;
                EfModel.Init().News.Add(New);
            }         
            else
            {
                EfModel.Init().News.Update(New);
            }
            EfModel.Init().SaveChanges();
            MessageBox.Show("Успешно");
            NavigationService.GoBack();
        }

        private void btnAddPhotoClick(object sender, RoutedEventArgs e)
        {   
    
            OpenFileDialog dialog= new OpenFileDialog();
            dialog.Multiselect = true;
           dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.jfif";
          if(dialog.ShowDialog()== true)
            {
                New.Photo = File.ReadAllBytes(dialog.FileName);
                imgPhoto.Source = ImageConverter.ConvertPhoto(New.Photo);

            }

        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
