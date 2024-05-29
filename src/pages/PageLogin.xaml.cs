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
    /// Interaction logic for PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;

            User user = UserManager.AuthenticateUser(username, password);
            if (user != null)
            {
                // Erfolgreiche Login-Nachricht anzeigen
                MessageBox.Show("Login successful!");
                // Hier kannst du die Logik nach erfolgreichem Login hinzufügen, z.B. Fenster wechseln
                PageHome pageHome = new PageHome();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.NavigateToPage(pageHome);
            }
            else
            {
                // Fehlermeldung anzeigen, wenn die Authentifizierung fehlschlägt
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
