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
    /// Interaction logic for PageAufgabe.xaml
    /// </summary>
    public partial class PageAufgabe : Page
    {
        QuestionList QuestionList = new QuestionList();
        Question CurrentQuestion;
        public PageAufgabe(QuestionList questions)
        {
            InitializeComponent();
            Log.log.Information("Aufgaben Page geöffnet");
            QuestionList = questions;
            foreach (Question question in QuestionList)
            {
                question.btnNextQuestion = btnNextQuestion;
            }
            CurrentQuestion = QuestionList.GetRandomQuestion();
            CurrentQuestion = (Question)CurrentQuestion.Copy();
            CurrentQuestion.Draw(grid);
        }

        private void btnNextQuestion_Click(object sender, RoutedEventArgs e)
        {
            Log.log.Information("Nächste Frage");
            CurrentQuestion = QuestionList.GetRandomQuestion();
            CurrentQuestion = (Question)CurrentQuestion.Copy();
            CurrentQuestion.Draw(grid);
            btnNextQuestion.Visibility = Visibility.Hidden;
        }
    }
}
