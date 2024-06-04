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
            Height = 50,
            Width = 100,
            Content = "Yes"
        };
        Button no = new Button()
        {
            Height = 50,
            Width = 100,
            Content = "No"
        };
        public YesNo(string text, string subject, string correctAnswer, int counter, DateTime lastUsed) 
        {
            Text = text;
            Subject = subject;
            Counter = counter;
            LastUsed = lastUsed;
            if (correctAnswer.ToLower() == "yes" || correctAnswer.ToLower() == "no")
            {
                CorrectAnswer = correctAnswer;
            }
            else
            {
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
            Grid.SetRow(yes, 1);
            yes.Click += Click;
            yes.IsEnabled = true;

            no.IsEnabled = true;
            no.Click += Click;
            Grid.SetColumn(no, 2);
            Grid.SetRow(no, 1);

            grid.Children.Add(textblockQuestion);
            grid.Children.Add(yes);
            grid.Children.Add(no);
            grid.Children.Add(btnNextQuestion);


        }
        public override object Copy()
        {
            YesNo question = new YesNo(Text,Subject,CorrectAnswer, Counter, LastUsed);
            question.btnNextQuestion = btnNextQuestion;
            question.textblockQuestion = textblockQuestion;
            return question;
        }
        private void Click(object sender, RoutedEventArgs e)
        {
            
            TextBlock textBlock = new TextBlock()
            {
                Height = 200,
                Width = 600,
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(textBlock, 1);
            Grid.SetRow(textBlock, 2);
            Grid.SetColumnSpan(textBlock, 3);
            if (sender is Button button)
            {
                string answer = button.Content.ToString().ToLower();
                if (CheckAnswer(answer))
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
