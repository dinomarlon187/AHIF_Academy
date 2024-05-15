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
            if (grid == null) return;
        }
    }
}
