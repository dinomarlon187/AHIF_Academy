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

        public static User CurrentUser { get; private set; }
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
                CurrentUser = user; 
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

            User user = new User { Username = username, Password = password, Profilpicture =  "../pictures/katze.png"};
            users.Add(user);
            SavedUsers(users);
            CurrentUser = user;
            
            return true; 
        }
        public static void ChangeProfilePicture(string newProfilePicturePath)
        {
            List<User> users = LoadUsers();
            foreach (User user in users)
            {
                if (user.Username == CurrentUser.Username && user.Password == CurrentUser.Password)
                {
                    user.Profilpicture = newProfilePicturePath;
                    break;
                }
            }
            SavedUsers(users);

            
        }
    }
}
