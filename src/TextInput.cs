using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ahif_academy
{
    public class TextInput : Question
    {
        public string FalseAnswer { get; set; }

        
        public TextInput(string text, string subject, string answer, string falseAnswer) 
        { 
            Text = text;
            Subject = subject;
            CorrectAnswer = answer;
            FalseAnswer = falseAnswer;
        }
        public override void Draw(Grid grid)
        {
            grid.Children.Clear();
            TextBlock textBlock = new TextBlock()
            {
                Text = Text,
                FontSize = 20,
                TextWrapping = System.Windows.TextWrapping.Wrap,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            Grid.SetColumn(textBlock, 0);
            Grid.SetRow(textBlock, 0);
            Grid.SetColumnSpan(textBlock, 3);


            TextBox textBox = new TextBox()
            {
                Height = 50,
                Width = 100,
                Text = FalseAnswer,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            Grid.SetColumn(textBox, 0);
            Grid.SetRow(textBox, 1);
            Grid.SetColumnSpan(textBox, 3);


            Button submit = new Button()
            {
                Height = 50,
                Width = 100,
                Content = "Submit"
            };
            Grid.SetColumn(submit, 1);
            Grid.SetRow(submit, 2);
        
            submit.Click += Submit_Click;
            grid.Children.Add(textBlock);
            grid.Children.Add(textBox);
            grid.Children.Add(submit);
        }

        private void Submit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            if (sender is Button)
            {
                Button button = (Button)sender;
                Grid grid = (Grid)button.Parent;
                TextBox textBox = (TextBox)grid.Children[1];
                button.IsEnabled = false;
                textBox.IsReadOnly = true;
                if (CheckAnswer(textBox.Text.Trim()))
                {
                    textBox.Background = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    textBox.Background = System.Windows.Media.Brushes.Red;
                    textBox.ToolTip = CorrectAnswer;
                }
            }
        }
    }
}
