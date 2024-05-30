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
    /// Interaction logic for PageEnglisch.xaml
    /// </summary>
    public partial class PageEnglisch : Page
    {
        private List<Flashcard> _flashcards;
        private int _currentIndex;
        private FlashcardService _flashcardService;

        public PageEnglisch()
        {
            InitializeComponent();
            _flashcardService = new FlashcardService();
            _flashcards = _flashcardService.LoadFlashcards();
            if (_flashcards.Count > 0)
            {
                _currentIndex = 0;
                DisplayFlashcard();
            }
        }

        private void DisplayFlashcard()
        {
            var flashcard = _flashcards[_currentIndex];
            EnglishTextBlock.Text = flashcard.English;
            GermanTextBlock.Text = flashcard.German;
            GermanTextBlock.Visibility = Visibility.Collapsed;
        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            GermanTextBlock.Visibility = Visibility.Visible;
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                DisplayFlashcard();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (_currentIndex < _flashcards.Count - 1)
            {
                _currentIndex++;
                DisplayFlashcard();
            }
        }
    }
}
