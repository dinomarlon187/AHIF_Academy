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
    /// Interaction logic for PageProfile.xaml
    /// </summary>
    public partial class PageProfile : Page
    {
        public string ImagePath { get; set; } = UserManager.CurrentUser.Profilpicture.ToString();
        public PageProfile()
        {
            InitializeComponent();
            Log.log.Information("Profil Page geöffnet");
            this.DataContext = this;
            benutzername.Text = UserManager.CurrentUser.Username;
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllgemeinButton.Background = new SolidColorBrush(Colors.Transparent);
            MatheButton.Background = new SolidColorBrush(Colors.Transparent);
            DeutschButton.Background = new SolidColorBrush(Colors.Transparent);
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Colors.AliceBlue);
                UserManager.CurrentUser.StatisticsDraw((string)button.Content, canvas);
            }
        }
    }
}
