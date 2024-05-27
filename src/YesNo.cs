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
        public YesNo(string text, string subject, string correctAnswer) 
        {
            Text = text;
            Subject = subject;
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

            Grid.SetColumn(textblockQuestion, 0);
            Grid.SetRow(textblockQuestion, 0);
            Grid.SetColumnSpan(textblockQuestion, 3);


            
            Grid.SetColumn(yes, 0);
            Grid.SetRow(yes, 1);
            yes.Click += Click;

            
            no.Click += Click;
            Grid.SetColumn(no, 2);
            Grid.SetRow(no, 1);

            grid.Children.Add(textblockQuestion);
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
                yes.IsEnabled = false;
                no.IsEnabled = false;
                grid.Children.Add(textBlock);
            }
            
        }


    }
}
