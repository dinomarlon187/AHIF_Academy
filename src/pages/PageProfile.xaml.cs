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
            this.DataContext = this;
            benutzername.Text = UserManager.CurrentUser.Username;
        }
    }
}
