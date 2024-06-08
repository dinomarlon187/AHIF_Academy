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
        public Button btnNextQuestion = new Button()
        {
            Width = 300,
            Height = 100,
            Content = "Nächste Frage",
            HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
            VerticalAlignment = System.Windows.VerticalAlignment.Top

        };
        protected TextBlock textblockQuestion = new TextBlock()
        {
            FontSize = 30,
            Width = 800,
            Height = 50,
            Foreground = System.Windows.Media.Brushes.Black,
            TextAlignment = System.Windows.TextAlignment.Center,
            Background = System.Windows.Media.Brushes.LightGray,
            TextWrapping = System.Windows.TextWrapping.Wrap,
            HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            VerticalAlignment = System.Windows.VerticalAlignment.Bottom
            
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
            List<User> users = UserManager.LoadUsers();
            foreach (User user in users)
            {
                if (user.Username == UserManager.CurrentUser.Username && user.Password == UserManager.CurrentUser.Password)
                {
                    if (correct)
                    {
                        if (subject.ToLower() == "deutsch")
                        {
                            user.QuestionsAnsweredCorrectDeutsch++;
                            UserManager.CurrentUser.QuestionsAnsweredCorrectDeutsch++;
                        }
                        else
                        {
                            user.QuestionsAnsweredCorrectMathe++;
                            UserManager.CurrentUser.QuestionsAnsweredCorrectMathe++;
                        }
                        
                    }
                    else
                    {
                        if (subject.ToLower() == "deutsch")
                        {
                            user.QuestionsAnsweredIncorrectDeutsch++;
                            UserManager.CurrentUser.QuestionsAnsweredIncorrectDeutsch++;
                        }
                        else
                        {
                            user.QuestionsAnsweredIncorrectMathe++;
                            UserManager.CurrentUser.QuestionsAnsweredIncorrectMathe++;
                        }
                    }
                }
            }
            UserManager.SavedUsers(users);
            

            

            return correct;
        }
        public abstract object Copy(); 


    }
}
