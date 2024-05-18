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
                TextWrapping = System.Windows.TextWrapping.Wrap
            };
            TextBox textBox = new TextBox()
            {
                Height = 50,
                Width = 100,
                Text = FalseAnswer
            };
            Button submit = new Button()
            {
                Height = 50,
                Width = 100,
                Content = "Submit"
            };
            grid.Children.Add(textBlock);
            grid.Children.Add(textBox);
            grid.Children.Add(submit);
        }
    }
}
