using AOA.LocalData;
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

namespace AOA.Pages.PagesAuth
{
    /// <summary>
    /// Interaction logic for FrontPage.xaml
    /// </summary>
    public partial class FrontPage : Page
    {
        public FrontPage()
        {
            InitializeComponent();
            
        }

        private void clicktbclAuth(object sender, MouseButtonEventArgs e)
        {
            new AuthWindow().ShowDialog();
            if(AuthUser.User!=null)
            {
                AuthUser.GetFIO();
                NavigationService.Navigate(new DataUserPage());
            }
        }

        private void ClickTblRegistr(object sender, MouseButtonEventArgs e)
        {
            new RegistrationWindow(new Connection.Entities.User()).ShowDialog();
        }
    }
}
