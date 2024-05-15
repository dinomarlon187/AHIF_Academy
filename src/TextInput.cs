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
            
        }
    }
}
