using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ahif_academy
{
    public class YesNo : Question
    {
        public override string Text { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CorrectAnswer { get; set; }


        public YesNo(string text, string subject, string correctAnswer) 
        {
            Text = text;
            Subject = subject;
            if (correctAnswer.ToLower() == "true" || correctAnswer.ToLower() == "false")
            {
                CorrectAnswer = bool.Parse(correctAnswer);
            }
            else
            {
                throw new ArgumentException("Correct answer must be either 'true' or 'false'");
            }

        }

        public override void Draw(Grid grid)
        {
            if (grid == null) return;
        }
        public override bool CheckAnswer(string answer)
        {
            throw new NotImplementedException();
        }
    }
}
