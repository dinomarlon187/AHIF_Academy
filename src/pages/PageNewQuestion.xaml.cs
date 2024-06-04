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
        QuestionList questions;
        public PageNewQuestion(QuestionList questions)
        {
            InitializeComponent();
            this.questions = questions;
            UpdateListBox(questions);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddQuestion windowAddQuestion = new WindowAddQuestion();
            windowAddQuestion.ShowDialog();
            if (windowAddQuestion.DialogResult == true)
            {
                questions.Add((Question)windowAddQuestion.question);
                UpdateListBox(questions);
                questions.SerializeToJSON();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            questions.Remove((Question)listBoxQuestions.SelectedItem);
            UpdateListBox(questions);
            questions.SerializeToJSON();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            questions.Remove((Question)listBoxQuestions.SelectedItem);
            WindowAddQuestion windowAddQuestion = new WindowAddQuestion((Question)listBoxQuestions.SelectedItem);
            windowAddQuestion.ShowDialog();
            if (windowAddQuestion.DialogResult == true)
            {
                questions.Add((Question)windowAddQuestion.question);
                UpdateListBox(questions);
                questions.SerializeToJSON();
            }
           
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            QuestionList filteredQuestions = new QuestionList();
            foreach (Question question in questions)
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
        }
    }
}
