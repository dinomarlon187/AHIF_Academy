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
        private List<Flashcard> flashcards;
        private int currentIndex;
        private FlashcardService flashcardService;

        public PageEnglisch()
        {
            InitializeComponent();
            flashcardService = new FlashcardService();
            flashcards = flashcardService.LoadFlashcards();
            if (flashcards.Count > 0)
            {
                currentIndex = 0;
                DisplayFlashcard();
                UpdateVocabularyList();
            }
        }

        private void DisplayFlashcard()
        {
            var flashcard = flashcards[currentIndex];
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
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayFlashcard();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < flashcards.Count - 1)
            {
                currentIndex++;
                DisplayFlashcard();
            }
        }

        private void AddVocabulary_Click(object sender, RoutedEventArgs e)
        {
            
            var newEnglish = NewEnglishTextBox.Text;
            var newGerman = NewGermanTextBox.Text;

            if (!string.IsNullOrWhiteSpace(newEnglish) && !string.IsNullOrWhiteSpace(newGerman))
            {
                var newFlashcard = new Flashcard { English = newEnglish, German = newGerman };
                flashcards.Add(newFlashcard);

                
                flashcardService.SaveFlashcards(flashcards);

                
                NewEnglishTextBox.Text = string.Empty;
                NewGermanTextBox.Text = string.Empty;

                
                currentIndex = flashcards.Count - 1;
                DisplayFlashcard();
                UpdateVocabularyList();


            }
            
        }
        private void UpdateVocabularyList()
        {
            VocabularyListBox.Items.Clear();
            foreach (var flashcard in flashcards)
            {
                VocabularyListBox.Items.Add($"{flashcard.English} - {flashcard.German}");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int selected = VocabularyListBox.SelectedIndex;
            if(selected  != null)
            {
                flashcards.RemoveAt(selected);
                flashcardService.SaveFlashcards(flashcards);
                DisplayFlashcard();
                UpdateVocabularyList();
            }
        }
    }
}
