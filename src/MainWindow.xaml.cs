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
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = sidebar.SelectedItem as NavButton;
            string subject = selected.ToolTip.ToString();
           /* navframe.Navigate(selected.Navlink);*/
            if(subject == "Mathe" || subject == "Deutsch" || subject == "Englisch")
            {
                navframe.Navigate(new PageAufgabe());
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