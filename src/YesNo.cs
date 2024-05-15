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
            
        }
    }
}
