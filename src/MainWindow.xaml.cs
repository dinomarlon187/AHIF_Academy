﻿using ahif_academy.pages;
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
                    q = UserManager.CurrentUser.Questions.FilterBySubject(subject);
                    if (q.GetAmount() < 5)
                    {
                        MessageBox.Show($"Zu wenig Fragen in der Fragenliste. Bitte Fragen vom Fach {subject} hinzufügen, bis es mindestens 5 Fragen sind.");
                        Log.log.Warning($"Versuch, mit weniger als 5 Fragen im Fach {subject} die jeweilige Page zu öffnen.");
                    }
                    else
                    {
                        navframe.Navigate(new PageAufgabe(q));
                    }

                }
                else if (subject == "Deutsch")
                {
                    QuestionList q;
                    q = UserManager.CurrentUser.Questions.FilterBySubject(subject);
                    if (q.GetAmount() < 5)
                    {
                        MessageBox.Show($"Zu wenig Fragen in der Fragenliste. Bitte Fragen vom Fach {subject} hinzufügen, bis es mindestens 5 Fragen sind.");
                        Log.log.Warning($"Versuch, mit weniger als 5 Fragen im Fach {subject} die jeweilige Page zu öffnen.");
                    }
                    else
                    {
                        navframe.Navigate(new PageAufgabe(q));
                    }
                }
                else if (subject == "Englisch")
                {
                    navframe.Navigate(new PageEnglisch());
                }
                else if (subject == "Einstellungen")
                {
                    navframe.Navigate(new PageEinstellungen());


                }
                else if (subject == "Home")
                {
                    navframe.Navigate(new PageHome());
                }
                else if (subject == "Profil")
                {
                    navframe.Navigate(new PageProfile());

                }
                else if (subject == "Frage hinzufügen") 
                {                     
                    navframe.Navigate(new PageNewQuestion());
                }
                
                
            }
        }
    }
}