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
            FontSize = 40,
            TextWrapping = System.Windows.TextWrapping.Wrap,
            HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
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
        public bool CheckAnswer(string answer, string subject)
        {
            bool correct = answer == CorrectAnswer;
            if (correct)
            {
                if (subject.ToLower() == "deutsch")
                {
                    UserManager.CurrentUser.QuestionsAnsweredCorrectDeutsch++;
                }
                else
                {
                    UserManager.CurrentUser.QuestionsAnsweredCorrectMathe++;
                }
            }
            else
            {
                if (subject.ToLower() == "deutsch")
                {
                    UserManager.CurrentUser.QuestionsAnsweredIncorrectDeutsch++;
                }
                else
                {
                    UserManager.CurrentUser.QuestionsAnsweredIncorrectMathe++;
                }
            }
            return correct;
        }
        public abstract object Copy(); 


    }
}
