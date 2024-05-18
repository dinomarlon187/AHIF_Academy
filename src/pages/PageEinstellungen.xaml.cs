﻿using System;
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
    /// Interaction logic for PageEinstellungen.xaml
    /// </summary>
    public partial class PageEinstellungen : Page
    {
        public PageEinstellungen()
        {
            InitializeComponent();
        }
        private void ThemeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Themes/Darkmode.xaml", UriKind.Relative));
            
        }

        private void ThemeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Themes/WhiteMode.xaml", UriKind.Relative));
            
        }
    }
}