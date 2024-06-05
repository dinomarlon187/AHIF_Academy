using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ahif_academy
{
    internal class UserManager
    {
        private static string filePath = "../../../JSONFiles/profiles.json";
        private static string filepathquestions = "../../../JSONFiles/questions.json";
        public static QuestionList QuestionList = new QuestionList();

        public static User CurrentUser { get; private set; }

        public UserManager()
        {
            if (!File.Exists(filepathquestions))
            {
                
            }
        }
        public static void SavedUsers(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static List<User> LoadUsers()
        {
            if (!File.Exists(filePath))
            {
                return new List<User>();
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        

        public static User AuthenticateUser(string username, string password)
        {
            List<User> users = LoadUsers();
            User user = users.Find(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                
                CurrentUser = user; // Setzen des aktuellen Benutzers
                QuestionList.DeserializeFromJSON(user.filepathuser, CurrentUser.Questions);
                user.filepathuser = "../../../JSONFiles/" + username + ".json";

            }
            return user;
        }
        public static bool RegisterUser(string username, string password)
        {
            List<User> users = LoadUsers();

            if (users.Exists(u => u.Username == username))
            {
                return false; 
            }
            User user = new User { Username = username, Password = password };

            user.filepathuser = "../../../JSONFiles/" + username + ".json";
            users.Add(user);
            SavedUsers(users);
            CurrentUser = user;
            QuestionList.DeserializeFromJSON(filepathquestions, CurrentUser.Questions);
            QuestionList.SerializeToJSON(user.filepathuser, CurrentUser.Questions);


            return true; 
        }
    }
}
