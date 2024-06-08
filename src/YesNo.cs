using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ahif_academy
{
    public class YesNo : Question
    {
        Button yes = new Button()
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            Content = "Yes",
            Margin = new Thickness(10, 10, 10, 10)
        };
        Button no = new Button()
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            Content = "No",
            Margin = new Thickness(10, 10, 10, 10)
        };
        public YesNo(string text, string subject, string correctAnswer) 
        {
            Text = text;
            Subject = subject;
            Type = "YesNo";
            if (correctAnswer.ToLower() == "yes" || correctAnswer.ToLower() == "no")
            {
                CorrectAnswer = correctAnswer;
            }
            else
            {
                Log.log.Warning("Versuch, eine Yes/No Frage mit einer ungültigen Antwort zu erstellen");
                throw new ArgumentException("Correct answer must be either 'yes' or 'no'");
            }

            textblockQuestion.Text = Text;

        }

        

        public override void Draw(Grid grid)
        {
            grid.Children.Clear();
            Grid.SetColumn(textblockQuestion, 0);
            Grid.SetRow(textblockQuestion, 0);
            Grid.SetColumnSpan(textblockQuestion, 3);


            
            Grid.SetColumn(yes, 0);
            Grid.SetRow(yes, 2);
            yes.Click += Click;
            yes.IsEnabled = true;

            no.IsEnabled = true;
            no.Click += Click;
            Grid.SetColumn(no, 2);
            Grid.SetRow(no, 2);

            grid.Children.Add(textblockQuestion);
            grid.Children.Add(yes);
            grid.Children.Add(no);
            grid.Children.Add(btnNextQuestion);


        }
        public override object Copy()
        {
            YesNo question = new YesNo(Text,Subject,CorrectAnswer);
            question.btnNextQuestion = btnNextQuestion;
            question.textblockQuestion = textblockQuestion;
            return question;
        }
        private void Click(object sender, RoutedEventArgs e)
        {
            
            TextBlock textBlock = new TextBlock()
            {
                FontSize = 60,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(textBlock, 1);
            Grid.SetRow(textBlock, 1);
            if (sender is Button button)
            {
                string answer;
                if (button == yes)
                {
                    answer = "Yes";
                }
                else
                {
                    answer = "No";
                }
                if (CheckAnswer(answer, Subject))
                {
                    textBlock.Text = "Correct";
                }
                else
                {
                    textBlock.Text = "Incorrect";
                }
                Grid grid = (Grid)button.Parent;
                yes.IsEnabled = false;
                no.IsEnabled = false;
                grid.Children.Add(textBlock);
                btnNextQuestion.IsEnabled = true;
                btnNextQuestion.Visibility = Visibility.Visible;
            }
            
        }
        public override string ToString()
        {
            return $"Subject: {Subject}, Text: {Text}, Richtige Antwort: {CorrectAnswer}";
        }


    }
}
