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

namespace ahif_academy.pages
{
    /// <summary>
    /// Interaction logic for PageHome.xaml
    /// </summary>
    public partial class PageHome : Page
    {

        public PageHome()
        {
            InitializeComponent();

            
            if (UserManager.CurrentUser != null)
            {
                benutzer.Text = UserManager.CurrentUser.Username;
                ButtonAnmelden.Visibility = Visibility.Collapsed;
                ButtonRegistrieren.Visibility = Visibility.Collapsed;
            }
            else
            {
                benutzer.Text = "Nicht angemeldet";
            }
        }

        private void ButtonAnmelden_Click(object sender, RoutedEventArgs e)
        {
            PageLogin pageLogin = new PageLogin();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToPage(pageLogin);
        }

        private void ButtonRegistrieren_Click(object sender, RoutedEventArgs e)
        {
            PageSign pageSign = new PageSign();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToPage(pageSign);
        }
    }
}
