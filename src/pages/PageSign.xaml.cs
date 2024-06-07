using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for PageSign.xaml
    /// </summary>
    public partial class PageSign : Page
    {
        SolidColorBrush gray = new SolidColorBrush(Colors.Gray);
        SolidColorBrush black = new SolidColorBrush(Colors.Black);
        public PageSign()
        {
            InitializeComponent();
            UsernameBox.Text = "Benutzername";  
            UsernameBox.Foreground = gray;
            placeholderPassword.Text = "Passwort";  
            placeholderPassword.Foreground = gray;
            

            Log.log.Information("Registrieren Page geöffnet");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            bool success  = UserManager.RegisterUser(username, password);

            if (success)
            {
                MessageBox.Show("Erfolgreich registriert!");
                Log.log.Information("Neuen User registriert");
                PageHome pageHome = new PageHome();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.NavigateToPage(pageHome);
            }
            else
            {
                MessageBox.Show("Benutzername existiert schon.");
            }
        }


        private void PlaceholderPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholderPassword.Visibility = Visibility.Collapsed;
            PasswordBox.Visibility = Visibility.Visible;
            PasswordBox.Focus(); 
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                placeholderPassword.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Collapsed;
            }
        }

        private void UsernameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text == "Benutzername")
            {
                UsernameBox.Text = "";
                UsernameBox.Foreground = black;
            }
        }

        private void UsernameBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameBox.Text))
            {
                UsernameBox.Text = "Benutzername";
                UsernameBox.Foreground = gray;
            }
        }
    }
}
