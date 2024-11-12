using AOA.Connection.Entities;
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

namespace AOA.Pages.NewsPages
{
    /// <summary>
    /// Interaction logic for NewInfoPage.xaml
    /// </summary>
    public partial class NewInfoPage : Page
    {
        public NewInfoPage(News news)
        {
            InitializeComponent();
            DataContext = news;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
