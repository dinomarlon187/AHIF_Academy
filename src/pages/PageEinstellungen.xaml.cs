using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for PageEinstellungen.xaml
    /// </summary>
    public partial class PageEinstellungen : Page
    {
        public string ImagePath { get; set; } = UserManager.CurrentUser.Profilpicture.ToString();
        
        public PageEinstellungen()
        {
            InitializeComponent();
            this.DataContext = this;
            benutzername.Text = UserManager.CurrentUser.Username;
        }
        private void ThemeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Themes/Darkmode.xaml", UriKind.Relative));
            
        }

        private void ThemeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Themes/WhiteMode.xaml", UriKind.Relative));
            
        }

        

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = Profilbild.SelectedItem as ComboBoxItem;

            if (selected != null)
            {
                var imagePaths = new Dictionary<string, string>
        {
            { "Spiderman", "../pictures/spiderman.png" },
            { "Katze", "../pictures/katze.png" },
            { "Cool", "../pictures/cool_picture.png" },
            { "ToΣ", "../pictures/tos.png" }
        };

                string selectedName = selected.Content.ToString();

                if (imagePaths.ContainsKey(selectedName))
                {
                    string path = imagePaths[selectedName];
                    UserManager.ChangeProfilePicture(path);
                    ImagePath = path;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = changeBenutzername.Text;
            UserManager.ChangeUsername(newUsername);
            MessageBox.Show("Benutzername wurde geändert");
        }
    }
}
