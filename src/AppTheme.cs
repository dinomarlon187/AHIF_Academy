using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ahif_academy
{
    internal class AppTheme
    {
        public static void ChangeTheme(Uri ThemeUri)
        {
            ResourceDictionary Theme = new ResourceDictionary() { Source = ThemeUri };
            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(Theme);
        }

    }
}
