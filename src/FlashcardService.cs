using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ahif_academy
{
    class FlashcardService
    {
        private readonly string filePath;
        public FlashcardService()
        {
            filePath = UserManager.CurrentUser.filepathvocable;
        }

        public List<Flashcard> LoadFlashcards()
        {
            if (!File.Exists(filePath))
            {
                return new List<Flashcard>();
            }

            var json = File.ReadAllText(filePath);
            Log.log.Information("Karteikarten werden geladen");
            return JsonConvert.DeserializeObject<List<Flashcard>>(json);
        }

        public void SaveFlashcards(List<Flashcard> flashcards)
        {
            var json = JsonConvert.SerializeObject(flashcards, Formatting.Indented);
            Log.log.Information("Karteikarten werden gespeichert");
            File.WriteAllText(filePath, json);
        }
    }
}
