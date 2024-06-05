using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ahif_academy
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class Question
    {
        [JsonProperty]
        public string Type { get; set; }
        protected bool AnswerPressed = false;
        public Button btnNextQuestion = new Button();
        protected TextBlock textblockQuestion = new TextBlock()
        {
            FontSize = 20,
            TextWrapping = System.Windows.TextWrapping.Wrap
        };
        protected string subject;
        protected string[] subjects = { "mathe", "englisch", "deutsch" };
        [JsonProperty]
        public string Text { get; set; }
        [JsonProperty]
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
        [JsonProperty]
        public  string CorrectAnswer { get; set; }
        public DateTime LastUsed { get; set; }
        public int Counter { get; set; }
        public abstract void Draw(Grid grid);
        public bool CheckAnswer(string answer)
        {
            return answer == CorrectAnswer;
        }
        public abstract object Copy(); 


    }
}
