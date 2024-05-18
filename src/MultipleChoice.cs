using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ahif_academy
{
    class MultipleChoice : Question
    {
        public string[] Answers { get; set; }

        public MultipleChoice(string text, string ans1, string ans2, string ans3, string ans4, string correct, string subject)
        {
            Text = text;
            Answers = new string[] { ans1, ans2, ans3, ans4 };
            CorrectAnswer = correct;
            Subject = subject;
        }
        public override void Draw(Grid grid)
        {
            grid.Children.Clear();
            Button ans1 = new Button()
            {
                Height = 50,
                Width = 100,
                Content = Answers[0]
            };
            Button ans2 = new Button()
            {
                Height = 50,
                Width = 100,
                Content = Answers[1]
            };
            Button ans3 = new Button()
            {
                Height = 50,
                Width = 100,
                Content = Answers[2]
            };
            Button ans4 = new Button()
            {
                Height = 50,
                Width = 100,
                Content = Answers[3]
            };
            TextBlock textBlock = new TextBlock()
            {
                Text = Text,
                FontSize = 20,
                TextWrapping = System.Windows.TextWrapping.Wrap
            };
            grid.Children.Add(textBlock);
            grid.Children.Add(ans1);
            grid.Children.Add(ans2);
            grid.Children.Add(ans3);
            grid.Children.Add(ans4);
        }
    }
}
