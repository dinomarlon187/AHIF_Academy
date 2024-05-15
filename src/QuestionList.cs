using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ahif_academy
{
    class QuestionList
    {
        private List<Question> questions = new List<Question>();

        public void DeserializeFromJSON()
        {
            string jsonString = System.IO.File.ReadAllText("Questions.json");
            questions = JsonSerializer.Deserialize<List<Question>>(jsonString);
        }
        public Question GetRandomQuestion()
        {
            Random random = new Random();
            int index = random.Next(questions.Count);
            return questions[index];
        }

    }
}
