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
        public YesNo(string text, string subject, string correctAnswer) 
        {
            Text = text;
            Subject = subject;
            if (correctAnswer.ToLower() == "true" || correctAnswer.ToLower() == "false")
            {
                CorrectAnswer = correctAnswer;
            }
            else
            {
                throw new ArgumentException("Correct answer must be either 'true' or 'false'");
            }

        }

        public override void Draw(Grid grid)
        {
            grid.Children.Clear();
            TextBlock textBlock = new TextBlock()
            {
                Text = Text,
                FontSize = 20,
                TextWrapping = System.Windows.TextWrapping.Wrap
            };
            Grid.SetColumn(textBlock, 0);
            Grid.SetRow(textBlock, 0);
            Grid.SetColumnSpan(textBlock, 3);


            Button yes = new Button()
            {
                Height = 50,
                Width = 100,
                Content = "Yes"
            };
            Grid.SetColumn(yes, 0);
            Grid.SetRow(yes, 1);
            yes.Click += Click;

            Button no = new Button()
            {
                Height = 50,
                Width = 100,
                Content = "No"
            };
            no.Click += Click;
            Grid.SetColumn(no, 2);
            Grid.SetRow(no, 1);
            grid.Children.Add(textBlock);
            grid.Children.Add(yes);
            grid.Children.Add(no);

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
                Button button1 = (Button)grid.Children[1];
                Button button2 = (Button)grid.Children[2];
                button1.IsEnabled = false;
                button2.IsEnabled = false;
                grid.Children.Add(textBlock);
                
                
            }
        }
    }
}
