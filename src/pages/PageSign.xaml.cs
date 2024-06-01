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
    /// Interaction logic for PageSign.xaml
    /// </summary>
    public partial class PageSign : Page
    {
        public PageSign()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            bool success  = UserManager.RegisterUser(username, password);

            if (success)
            {
                MessageBox.Show("Registration successful!");
                PageHome pageHome = new PageHome();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.NavigateToPage(pageHome);
            }
            else
            {
                MessageBox.Show("Username already exists.");
            }
        }
    }
}
