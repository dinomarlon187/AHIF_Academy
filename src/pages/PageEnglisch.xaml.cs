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
                UpdateVocabularyList();
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

        private void AddVocabulary_Click(object sender, RoutedEventArgs e)
        {
            // Neue Vokabel aus den TextBoxen erstellen
            var newEnglish = NewEnglishTextBox.Text;
            var newGerman = NewGermanTextBox.Text;

            if (!string.IsNullOrWhiteSpace(newEnglish) && !string.IsNullOrWhiteSpace(newGerman))
            {
                var newFlashcard = new Flashcard { English = newEnglish, German = newGerman };
                _flashcards.Add(newFlashcard);

                // Speichern der aktualisierten Liste der Karteikarten
                _flashcardService.SaveFlashcards(_flashcards);

                // Leeren der TextBoxen
                NewEnglishTextBox.Text = string.Empty;
                NewGermanTextBox.Text = string.Empty;

                // Zeige die neue Karteikarte an
                _currentIndex = _flashcards.Count - 1;
                DisplayFlashcard();
                UpdateVocabularyList();


            }
            
        }
        private void UpdateVocabularyList()
        {
            VocabularyListBox.Items.Clear();
            foreach (var flashcard in _flashcards)
            {
                VocabularyListBox.Items.Add($"{flashcard.English} - {flashcard.German}");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int selected = VocabularyListBox.SelectedIndex;
            if(selected  != null)
            {
                _flashcards.RemoveAt(selected);
                _flashcardService.SaveFlashcards(_flashcards);
                DisplayFlashcard();
                UpdateVocabularyList();
            }
        }
    }
}
