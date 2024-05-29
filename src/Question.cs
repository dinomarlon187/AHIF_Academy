using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ahif_academy
{
    public abstract class Question
    {
        protected bool AnswerPressed = false;
        public Button btnNextQuestion = new Button();
        protected TextBlock textblockQuestion = new TextBlock()
        {
            FontSize = 20,
            TextWrapping = System.Windows.TextWrapping.Wrap
        };
        protected string subject;
        protected string[] subjects = { "mathe", "englisch", "deutsch" };
        public string Text { get; set; }
        public string Subject 
        {
            get
            {
                return subject;
            }
            set
            {
                if (subjects.Contains<string>(value.ToLower()))
                {
                    subject = value;
                }
                else
                {
                    throw new ArgumentException("Subject must be either 'mathe', 'englisch' or 'deutsch'");
                }
                    
            }
        }

        public  string CorrectAnswer { get; set; }
        public abstract void Draw(Grid grid);
        public bool CheckAnswer(string answer)
        {
            return answer == CorrectAnswer;
        }
        public abstract object Copy(); 


    }
}
