using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;



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
            Log.log.Information($"Benutzer in JSON Datei {filePath} gespeichert");
        }

        public static List<User> LoadUsers()
        {
            if (!File.Exists(filePath))
            {
                return new List<User>();
            }
            string json = File.ReadAllText(filePath);
            Log.log.Information($"Benutzer werden aus der JSON Datei {filePath} geladen");
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        

        public static User AuthenticateUser(string username, string password)
        {
            List<User> users = LoadUsers();
            string hashedPassword = HashPassword(password);
            User user = users.Find(u => u.Username == username && u.Password == hashedPassword);
            if (user != null)
            {
                user.filepathuser = "../../../JSONFiles/" + username + ".json";
                CurrentUser = user; // Setzen des aktuellen Benutzers
                QuestionList.DeserializeFromJSON(user.filepathuser, CurrentUser.Questions);
                Log.log.Information($"{CurrentUser.Username} hat sich eingeloggt");
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
            string hashedPassword = HashPassword(password);

            User user = new User { Username = username, Password = hashedPassword, Profilpicture =  "../pictures/katze.png"};
            user.filepathuser = "../../../JSONFiles/" + username + ".json";
            Log.log.Information($"{user.Username} hat sich registriert");
            users.Add(user);
            SavedUsers(users);
            CurrentUser = user;
            QuestionList.DeserializeFromJSON(filepathquestions, CurrentUser.Questions);
            QuestionList.SerializeToJSON(user.filepathuser, CurrentUser.Questions);


            return true; 
        }
        public static void ChangeProfilePicture(string newProfilePicturePath)
        {
            List<User> users = LoadUsers();
            foreach (User user in users)
            {
                if (user.Username == CurrentUser.Username && user.Password == CurrentUser.Password)
                {
                    user.Questions = CurrentUser.Questions;
                    user.Profilpicture = newProfilePicturePath;
                    CurrentUser = user;
                    Log.log.Information("Profilbild geändert.");
                    break;
                }
            }
            SavedUsers(users); 
        }
        public static void ChangeUsername(string newUsername)
        {
            List<User> users = LoadUsers();
            foreach (User user in users)
            {
                if (user.Username == CurrentUser.Username && user.Password == CurrentUser.Password)
                {
                    user.Username = newUsername;
                    File.Move(user.filepathuser, "../../../JSONFiles/" + user.Username + ".json");
                    user.filepathuser = "../../../JSONFiles/" + user.Username + ".json";
                    QuestionList.DeserializeFromJSON(user.filepathuser, user.Questions);
                    CurrentUser = user;
                    Log.log.Information("Benutzername geändert.");
                    break;
                }
            }
            SavedUsers(users); 
        }
        private static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
