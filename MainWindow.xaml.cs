using AOA.Connection;
using AOA.Pages.PagesAuth;
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

namespace AOA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame RightSide;
        public static Frame Auth;
        public MainWindow()
        {
            InitializeComponent();
            EfModel.Init();
            AuthNavigation.Navigate(new FrontPage());
            PageNavigation.Navigate(new NewsPage());
            Auth = PageNavigation;
            RightSide = AuthNavigation;
            EfModel.Init().OfferTypes.Add(new Connection.Entities.OfferType());
        }
    }
}
