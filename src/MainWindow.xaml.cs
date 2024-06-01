using ahif_academy.pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ahif_academy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuestionList questions = new QuestionList();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void NavigateToPage(Page page)
        {
            // Navigate to the given page
            navframe.Navigate(page);
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = sidebar.SelectedItem as NavButton;
            string subject = selected.ToolTip.ToString();
            if(subject == "Mathe")
            {
                questions.FilterBySubject("Mathe");
                navframe.Navigate(new PageAufgabe(questions));
            }
            else if(subject == "Deutsch")
            {
                questions.FilterBySubject("Deutsch");
                navframe.Navigate(new PageAufgabe(questions));
            }
            else if(subject == "Englisch")
            {
                questions.FilterBySubject("Englisch");
                navframe.Navigate(new PageEnglisch(questions));
            }
            else if (subject == "Einstellungen")
            {
                navframe.Navigate(new PageEinstellungen());

            }
            else if (subject == "Home")
            {
                navframe.Navigate(new PageHome());
            }
        }
    }
}