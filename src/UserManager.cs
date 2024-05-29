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
            return users.Find(u => u.Username == username && u.Password == password);
        }
    }
}
