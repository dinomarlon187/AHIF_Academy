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
    /// Interaction logic for PageNewQuestion.xaml
    /// </summary>
    public partial class PageNewQuestion : Page
    {
        User currentUser = UserManager.CurrentUser;
        public PageNewQuestion()
        {
            InitializeComponent();
            Log.log.Information("Fragenanzeige Page geöffnet");
            UpdateListBox(currentUser.Questions);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddQuestion windowAddQuestion = new WindowAddQuestion();
            windowAddQuestion.ShowDialog();
            if (windowAddQuestion.DialogResult == true)
            {
                currentUser.Questions.Add((Question)windowAddQuestion.question);
                UpdateListBox(currentUser.Questions);
                QuestionList.SerializeToJSON(currentUser.filepathuser, currentUser.Questions);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            currentUser.Questions.Remove((Question)listBoxQuestions.SelectedItem);
            UpdateListBox(currentUser.Questions);
            QuestionList.SerializeToJSON(currentUser.filepathuser, currentUser.Questions);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            currentUser.Questions.Remove((Question)listBoxQuestions.SelectedItem);
            WindowAddQuestion windowAddQuestion = new WindowAddQuestion((Question)listBoxQuestions.SelectedItem);
            windowAddQuestion.ShowDialog();
            if (windowAddQuestion.DialogResult == true)
            {
                currentUser.Questions.Add((Question)windowAddQuestion.question);
                UpdateListBox(currentUser.Questions);
                QuestionList.SerializeToJSON(currentUser.filepathuser, currentUser.Questions);
            }
           
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            QuestionList filteredQuestions = new QuestionList();
            foreach (Question question in currentUser.Questions)
            {
                if (question.Text.Contains(textBoxSearch.Text))
                {
                    filteredQuestions.Add(question);
                }
            }
            UpdateListBox(filteredQuestions);
        }
        private void UpdateListBox(QuestionList q)
        {
            listBoxQuestions.Items.Clear();
            foreach (Question question in q)
            {
                listBoxQuestions.Items.Add(question);
            }
            Log.log.Information("Fragenliste aktualisiert");
        }
    }
}
