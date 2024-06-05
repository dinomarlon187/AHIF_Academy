using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            foreach (var question in jsonObj.questions)
            {
                if (question.Type == "MultipleChoice")
                {
                    questions.Add(new MultipleChoice(question.Text.ToString(), question.Answers[0].ToString(), question.Answers[1].ToString(), question.Answers[2].ToString(), question.Answers[3].ToString(), question.CorrectAnswer.ToString(), question.Subject.ToString()));
                }
                else if (question.Type == "YesNo")
                {
                    questions.Add(new YesNo(question.Text.ToString(), question.Subject.ToString(), question.CorrectAnswer.ToString()));
                }
                else if (question.Type == "TextInput")
                {
                    questions.Add(new TextInput(question.Text.ToString(), question.Subject.ToString(), question.CorrectAnswer.ToString(),question.WrongAnswer.ToString()));
                }
                else
                {
                    throw new ArgumentException("Invalid question type");
                }
            }   
            
        }
        public static void SerializeToJSON(string path, QuestionList q)
        {
            string jsonString = JsonConvert.SerializeObject(q, Formatting.Indented);
            System.IO.File.WriteAllText(path, jsonString);
        }
        public Question GetRandomQuestion()
        {
            questions = questions.OrderBy(x => x.Counter).ThenBy(x => x.LastUsed).ToList();
            int index = random.Next(0,5);
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
        }
        public void Remove(Question question)
        {
            questions.Remove(question);
        }
    }
}
