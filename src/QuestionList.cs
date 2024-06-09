using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace ahif_academy
{
    public class QuestionList
    {
        [JsonProperty]
        private List<Question> questions = new List<Question>();
        Random random = new Random();

        public static void DeserializeFromJSON(string path, QuestionList questions)
        {
            string jsonString = System.IO.File.ReadAllText(path);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonString);
            int counterWrong = 0;
            int counterRight = 0;
            Log.log.Information($"Deserialisierung der Fragen von der JSON file {path} gestartet");
            
            foreach (var question in jsonObj.questions)
            {
                try
                {
                    if (question.Type == "MultipleChoice")
                    {
                        questions.Add(new MultipleChoice(question.Text.ToString(), question.Answers[0].ToString(), question.Answers[1].ToString(), question.Answers[2].ToString(), question.Answers[3].ToString(), question.CorrectAnswer.ToString(), question.Subject.ToString()));
                        counterRight++;
                    }
                    else if (question.Type == "YesNo")
                    {
                        questions.Add(new YesNo(question.Text.ToString(), question.Subject.ToString(), question.CorrectAnswer.ToString()));
                        counterRight++;
                    }
                    else if (question.Type == "TextInput")
                    {
                        questions.Add(new TextInput(question.Text.ToString(), question.Subject.ToString(), question.CorrectAnswer.ToString(), question.WrongAnswer.ToString()));
                        counterRight++;
                    }
                    else
                    {
                        Log.log.Warning("Eine Frage konnte nicht deserialisiert werden aufgrund eines unbekannten Fragetyps");
                        throw new ArgumentException("Invalid question type");
                    }
                }
                catch (Exception e)
                {
                    Log.log.Warning("Eine Frage konnte nicht deserialisiert werden");
                    counterWrong++;
                }
            }  
            if (counterRight == 0)
            {
                Log.log.Warning("0 Fragen wurden erfolgreich deserialisiert");
            }
            if (counterWrong > 0)
            {
                MessageBox.Show(counterWrong + " questions could not be loaded", "Warning");
            }
            Log.log.Information($"Deserialisierung der Fragen von der JSON file {path} beendet.");


        }
        public static void SerializeToJSON(string path, QuestionList q)
        {
            string jsonString = JsonConvert.SerializeObject(q, Formatting.Indented);
            System.IO.File.WriteAllText(path, jsonString);
            Log.log.Information($"Serialisierung der Fragen in die JSON file {path} beendet");
        }
        public Question GetRandomQuestion()
        {
            questions = questions.OrderBy(x => x.Counter).ThenBy(x => x.LastUsed).ToList();
            int index = random.Next(0,8);
            questions[index].Counter++;
            questions[index].LastUsed = DateTime.Now;
            return questions[index];
        }
        public QuestionList FilterBySubject(string subject)
        {
            QuestionList filteredList = new QuestionList();
            filteredList.questions = this.questions.Where(q => q.Subject.ToLower() == subject.ToLower()).ToList();
            return filteredList;
        }
        public IEnumerator GetEnumerator()
        {
            return questions.GetEnumerator();
        }
        public void Add(Question question)
        {
            questions.Add(question);
            Log.log.Information("Neue Frage hinzugefügt");
        }
        public void Remove(Question question)
        {
            questions.Remove(question);
            Log.log.Information("Frage gelöscht");
        }
        public int GetAmount()
        {
            return questions.Count;
        }
        public void SortbySubjects()
        {
            questions = questions.OrderBy(x => x.Subject).ToList();
        }
        public void Shuffle()
        {
            int n = questions.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Question q = questions[k];
                questions[k] = questions[n];
                questions[n] = q;
            }
        }
    }
}
