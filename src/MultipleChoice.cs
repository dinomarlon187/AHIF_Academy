using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ahif_academy
{
    class MultipleChoice : Question
    {
        [JsonProperty]
        public string[] Answers { get; set; }
        Button ans1 = new Button()
        {
            Height = 100,
            Width = 300,
            Margin = new Thickness(10),
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Bottom

        };
        Button ans2 = new Button()
        {
            Height = 100,
            Width = 300,
            Margin = new Thickness(10),
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Bottom
        };
        Button ans3 = new Button()
        {
            Height = 100,
            Width = 300,
            Margin = new Thickness(10),
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Top
        };
        Button ans4 = new Button()
        {
            Height = 100,
            Width = 300,
            Margin = new Thickness(10),
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top
        };

        public MultipleChoice(string text, string ans1, string ans2, string ans3, string ans4, string correct, string subject)
        {
            Text = text;
            Answers = new string[] { ans1, ans2, ans3, ans4 };
            CorrectAnswer = correct;
            Subject = subject;
            this.ans1.Content = Answers[0];
            this.ans2.Content = Answers[1];
            this.ans3.Content = Answers[2];
            this.ans4.Content = Answers[3];
            Type = "MultipleChoice";

        }
        public override void Draw(Grid grid)
        {
            
            
            Grid.SetRow(ans1, 1);
            Grid.SetColumn(ans1, 0);
            ans1.Click += Click;

            
            Grid.SetRow(ans2, 1);
            Grid.SetColumn(ans2, 1);
            ans2.Click += Click;

            
            Grid.SetRow(ans3, 2);
            Grid.SetColumn(ans3, 0);
            ans3.Click += Click;

            
            Grid.SetRow(ans4, 2);
            Grid.SetColumn(ans4, 1);
            ans4.Click += Click;

            textblockQuestion.Text = Text;
            Grid.SetColumnSpan(textblockQuestion, 2);
            grid.Children.Clear();
            grid.Children.Add(textblockQuestion);
            grid.Children.Add(ans1);
            grid.Children.Add(ans2);
            grid.Children.Add(ans3);
            grid.Children.Add(ans4);
            grid.Children.Add(btnNextQuestion);
        }
        
        private void Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && AnswerPressed == false)
            {
                AnswerPressed = true;
                if (CheckAnswer(button.Content.ToString(), Subject))
                {
                    button.Background = Brushes.Green;
                }
                else
                {
                    button.Background = Brushes.Red;
                }
                foreach (Button b in new Button[] { ans1, ans2, ans3, ans4 })
                {
                    if (b.Content.ToString() == CorrectAnswer)
                    {
                        b.Background = Brushes.Green;
                    }
                }

            
                if (button.Content.ToString() != CorrectAnswer)
                {
                    button.Background = Brushes.Red;
                }
                btnNextQuestion.IsEnabled = true;
                btnNextQuestion.Visibility = Visibility.Visible;
                
            }




        }

        public override object Copy()
        {
            MultipleChoice question = new MultipleChoice(Text, Answers[0], Answers[1], Answers[2], Answers[3], CorrectAnswer, Subject);
            question.btnNextQuestion = btnNextQuestion;
            question.textblockQuestion = textblockQuestion;
            return question;
        }
        public override string ToString()
        {
            return $"Subject: {Subject}, Text: {Text}, Richtige Antwort: {CorrectAnswer}, Antwort1: {Answers[0]},Antwort2:  {Answers[1]},Antwort3:  {Answers[2]},Antwort4:  {Answers[3]}";
        }
    }
}
