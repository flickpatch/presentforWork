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

namespace AOA.Windows
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        User u;
        public RegistrationWindow(User user)
        {
            InitializeComponent();
            if(AuthUser.User !=null)
            {
                tblTitle.Text = "Изменение информации";
                btnAddPhoto.Content = "Изменить фотографию";
                btnAuth.Content = "Изменить";
                u = AuthUser.User;
                DataContext = u;

            }
            else
            {
                u = user;
                DataContext = u;
            }
                     
            cbCompanies.ItemsSource = EfModel.Init().Companies.ToList();
        }

     
        private void SecPbChange(object sender, RoutedEventArgs e)
        {
           if (pbPass.Password != pbSecPass.Password)
           {
                    pbPass.Background = Brushes.Tomato;
           }
                else
                {
                    pbSecPass.Background = Brushes.Lime;
                    pbPass.Background = Brushes.Lime;
                    MessageBox.Show("Пароли совпали!");
                }
        }

        private void PbPassChange(object sender, RoutedEventArgs e)
        {
            if (pbPass.Password != "")
            {
                pbSecPass.IsEnabled = true;
            }
            else pbSecPass.IsEnabled = false;
        }

        private void btnAddPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.jfif";
            if(dialog.ShowDialog() == true)
            {
                u.Photo = File.ReadAllBytes(dialog.FileName);
                imgPhoto.Source = ImageConverter.ConvertPhoto(u.Photo);
            }
        }
        private bool CheckData(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return true;
            }

            return false;
        }
        private bool CheckNull(string str)
        {
            if(str == "")
                return true;
            return false;
        }
        private bool CheckInputData()
        {
            int sum =0;
           if(CheckNull(tbName.Text))
            {
                tblNameError.Visibility = Visibility.Visible;

            }
            else
            {
                if(CheckData(tbName.Text))
                {
                    sum = sum + 1;
                    tblNameError.Visibility = Visibility.Hidden;
                }
                else
                {
                    tblNameError.Visibility = Visibility.Visible;
                    tblNameError.Text = "Не может содержать цифры";
                    
                }
                
            }
            if (CheckNull(tbSecName.Text))
            {                                
                tblSecNameError.Visibility = Visibility.Visible;
            }
            else
            {
                if (CheckData(tbSecName.Text))
                {
                    sum = sum + 1;
                    tblSecNameError.Visibility = Visibility.Hidden;
                }
                else
                {
                    tblSecNameError.Visibility = Visibility.Visible;
                    tblSecNameError.Text = "Не может содержать цифры";
                }
               
            }
            if (CheckNull(tbMidName.Text))
            {
                tblMidNameError.Visibility = Visibility.Visible;

            }
            else
            {
                if (CheckData(tbMidName.Text))
                {
                    sum = sum + 1;
                    tblMidNameError.Visibility = Visibility.Hidden;
                }
                else
                {
                    tblMidNameError.Visibility = Visibility.Visible;
                    tblMidNameError.Text = "Не может содержать цифры";
                    
                }
                
            }
            if (CheckNull(tbEmail.Text))
            {
                tblLoginError.Visibility = Visibility.Visible;

            }
            else
            {
                tblLoginError.Visibility = Visibility.Hidden;
                sum = sum + 1;
            }
            if(tbPhoneNumber.Text == null)
            {
                tblPhoneError.Visibility = Visibility.Visible;
            }
            else
            {
                if (CheckData(tbPhoneNumber.Text))
                {
                    tblPhoneError.Visibility = Visibility.Visible;
                    tblPhoneError.Text = "Не может содержать буквы";
                }
                else
                {
                    sum = sum + 1;
                    tblPhoneError.Visibility = Visibility.Hidden;
                }

            }
            if (CheckNull(pbPass.Password))
            {
                tblFirstPassError.Visibility = Visibility.Visible;

            }
            else
            {
                tblFirstPassError.Visibility = Visibility.Hidden;
                sum = sum + 1;
            }
            if (CheckNull(pbSecPass.Password))
            {
                tblErrorPass2.Visibility = Visibility.Visible;

            }
            else
            {
                tblErrorPass2.Visibility = Visibility.Hidden;
                sum = sum + 1;
            }
            if (cbCompanies.SelectedItem as Company != null)
            {
                sum = sum + 1;
                tblErrorCompany.Visibility = Visibility.Hidden;
            }
            else
                tblErrorCompany.Visibility = Visibility.Visible;       
            if(u.Photo == null)
            {
                tblPhotoError.Visibility = Visibility.Visible;
            }
            else
            {
                tblPhotoError.Visibility = Visibility.Hidden;
                sum = sum + 1;
            }
            if(sum!=9)
            {
                sum = 0;
                return false;

            }
            sum = 0;
            return true;
        }

        private void btnADDClcik(object sender, RoutedEventArgs e)
        {
            Company company = cbCompanies.SelectedItem as Company;
            if (CheckInputData() == true)
            {


                u.Name = tbName.Text;
                u = DataContext as User;
                u.Pass = pbPass.Password;
                u.Company = company;
                u.Companyid = company.Id;
                try
                {


                    if (AuthUser.User == null)
                    {

                        EfModel.Init().Users.Add(u);
                        EfModel.Init().SaveChanges();
                        MessageBox.Show("Вы успешно зарегистровались!");

                    }
                    else
                    {

                        EfModel.Init().Users.Update(u);
                        EfModel.Init().SaveChanges();
                        MessageBox.Show("Изменено!");

                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
                Close();
            }
        }
    }
}
