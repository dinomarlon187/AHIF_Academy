﻿using System;
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
        private readonly string filePath = "../../../JSONFiles/vocable.json";

        public List<Flashcard> LoadFlashcards()
        {
            if (!File.Exists(filePath))
            {
                return new List<Flashcard>();
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Flashcard>>(json);
        }

        public void SaveFlashcards(List<Flashcard> flashcards)
        {
            var json = JsonConvert.SerializeObject(flashcards, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
