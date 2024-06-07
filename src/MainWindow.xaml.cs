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
        public MainWindow()
        {
            InitializeComponent();
            sidebar.SelectedItem = navbuttonHome;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void TitleMinimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void TitleMaximize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void TitleClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        public void NavigateToPage(Page page)
        {
            navframe.Navigate(page);
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = sidebar.SelectedItem as NavButton;
            if (UserManager.CurrentUser == null && selected != navbuttonHome)
            {
                MessageBox.Show("Sie sind nicht angemeldet. Bitte melden Sie sich an oder registrieren sie sich.");
                sidebar.SelectedItem = navbuttonHome;
                return;
            }
            else
            {

                string subject = selected.ToolTip.ToString();
                if (subject == "Mathe")
                {

                    QuestionList q;
                    q = UserManager.CurrentUser.Questions.FilterBySubject("Mathe");

                    //navframe.Navigate(new PageAufgabe(q));
                }
                else if (subject == "Deutsch")
                {
                    QuestionList q;
                    q = UserManager.CurrentUser.Questions.FilterBySubject("Deutsch");
                    navframe.Navigate(new PageAufgabe(q));
                }
                else if (subject == "Englisch")
                {
                    QuestionList q;
                    q = UserManager.CurrentUser.Questions.FilterBySubject("Englisch");
                    navframe.Navigate(new PageEnglisch());
                }
                else if (subject == "Einstellungen")
                {
                    if (UserManager.CurrentUser == null)
                    {
                        MessageBox.Show("Bitte loggen Sie sich ein");
                        navframe.Navigate(new PageLogin());
                    }
                    else
                    {
                        navframe.Navigate(new PageEinstellungen());
                    }

                }
                else if (subject == "Home")
                {
                    navframe.Navigate(new PageHome());
                }
                else if (subject == "Profil")
                {
                    if (UserManager.CurrentUser == null)
                    {
                        MessageBox.Show("Bitte loggen Sie sich ein");
                        navframe.Navigate(new PageLogin());
                    }
                    else
                    {
                        navframe.Navigate(new PageProfile());
                    }
                }
            }
        }
    }
}