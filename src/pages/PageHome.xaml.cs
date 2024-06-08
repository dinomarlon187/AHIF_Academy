using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        string text = "Herzlich willkommen an der AHIF ACADEMY! Diese App bietet dir eine großartige Gelegenheit, deine Fähigkeiten in den Bereichen Mathematik, Deutsch und Englisch zu verbessern.Jetzt bist du nur noch wenige Klicks von deinem Abenteuer entfernt. Melde dich an oder registriere dich um loszulegen!";
        public PageHome()
        {
            InitializeComponent();
            Log.log.Information("Home Page geöffnet");

            
            if (UserManager.CurrentUser != null)
            {
                benutzer.Text = UserManager.CurrentUser.Username;
                ButtonAnmelden.Visibility = Visibility.Collapsed;
                ButtonRegistrieren.Visibility = Visibility.Collapsed;
                text = "Nun kannst du mit deinem Abenteuer beginnen! Benutze einfach die intuitiven Icons an der linken Seite des Bildschirms und fang an!";
            }
            else
            {
                benutzer.Text = "Nicht angemeldet";
            }
            textBlockText.Text = text;
        }

        private void ButtonAnmelden_Click(object sender, RoutedEventArgs e)
        {
            PageLogin pageLogin = new PageLogin();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToPage(pageLogin);
            text = "Nun kannst du mit deinem Abenteuer beginnen! Benutze einfach die intuitiven Icons an der linken Seite des Bildschirms und fang an!";
        }

        private void ButtonRegistrieren_Click(object sender, RoutedEventArgs e)
        {
            PageSign pageSign = new PageSign();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToPage(pageSign);
            text = "Nun kannst du mit deinem Abenteuer beginnen! Benutze einfach die intuitiven Icons an der linken Seite des Bildschirms und fang an!";
        }
    }
}
