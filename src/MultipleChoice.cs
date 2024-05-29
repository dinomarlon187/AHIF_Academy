using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ahif_academy
{
    class MultipleChoice : Question
    {
        public string[] Answers { get; set; }
        Button ans1 = new Button()
        {
            Height = 50,
            Width = 100
        };
        Button ans2 = new Button()
        {
            Height = 50,
            Width = 100
        };
        Button ans3 = new Button()
        {
            Height = 50,
            Width = 100
        };
        Button ans4 = new Button()
        {
            Height = 50,
            Width = 100
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

        }
        public override void Draw(Grid grid)
        {
            grid.Children.Clear();
            
            Grid.SetRow(ans1, 1);
            Grid.SetColumn(ans1, 0);
            ans1.Click += Click;

            
            Grid.SetRow(ans2, 1);
            Grid.SetColumn(ans2, 1);
            ans2.Click += Click;

            
            Grid.SetRow(ans3, 1);
            Grid.SetColumn(ans3, 2);
            ans3.Click += Click;

            
            Grid.SetRow(ans4, 1);
            Grid.SetColumn(ans4, 3);
            ans4.Click += Click;

            textblockQuestion.Text = Text;

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
                if (Answers[0] == CorrectAnswer)
                {
                    ans1.Background = Brushes.Green; 
                }
                else if (Answers[1] == CorrectAnswer)
                {
                    ans2.Background = Brushes.Green;
                }
                else if (Answers[2] == CorrectAnswer)
                {
                    ans3.Background = Brushes.Green;
                }
                else
                {
                    ans4.Background = Brushes.Green;
                }

            
                if (button.Content.ToString() != CorrectAnswer)
                {
                    button.Background = Brushes.Red;
                }
                btnNextQuestion.IsEnabled = true;
                btnNextQuestion.Visibility = Visibility.Visible;
            
        }

    }
}
