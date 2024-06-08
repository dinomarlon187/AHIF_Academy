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
            Margin = new Thickness(170, 70, 130, 70)
        };
        Button no = new Button()
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            Content = "No",
            Margin = new Thickness(130, 70, 170, 70)
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
            grid.Children.Clear();
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
                Height = 200,
                Width = 200,
                TextAlignment = TextAlignment.Center,
                FontSize = 30,
                FontWeight = FontWeights.Bold,
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            
            Grid.SetRow(textBlock, 1);
            Grid.SetColumnSpan(textBlock, 2);
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
                    textBlock.Foreground = System.Windows.Media.Brushes.Green;
                    textBlock.Text = "Richtig";
                }
                else
                {
                    textBlock.Foreground = System.Windows.Media.Brushes.Red;
                    textBlock.Text = "Falsch";
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
