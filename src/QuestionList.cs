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
        private List<Question> questions = new List<Question>();
        Random random = new Random();
        public string CurrentSubject { get; set; }

        public void DeserializeFromJSON()
        {
            string jsonString = System.IO.File.ReadAllText("../../../JSONFiles/Questions.json");
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonString);
            foreach (var question in jsonObj)
            {
                if (question.Type == "MultipleChoice")
                {
                    questions.Add(new MultipleChoice(question.Text.ToString(), question.Answers[0].ToString(), question.Answers[1].ToString(), question.Answers[2].ToString(), question.Answers[3].ToString(), question.CorrectAnswer.ToString(), question.Subject.ToString(), Convert.ToInt16(question.Counter), Convert.ToDateTime(question.LastUsed)));
                }
                else if (question.Type == "YesNo")
                {
                    questions.Add(new YesNo(question.Text.ToString(), question.Subject.ToString(), question.CorrectAnswer.ToString(), Convert.ToInt16(question.Counter), Convert.ToDateTime(question.LastUsed)));
                }
                else if (question.Type == "TextInput")
                {
                    questions.Add(new TextInput(question.Text.ToString(), question.Subject.ToString(), question.CorrectAnswer.ToString(),question.WrongAnswer.ToString(), Convert.ToInt16(question.Counter), Convert.ToDateTime(question.LastUsed)));
                }
                else
                {
                    throw new ArgumentException("Invalid question type");
                }
            }   
            
        }
        public void SerializeToJSON()
        {
            string jsonString = JsonConvert.SerializeObject(questions);
            System.IO.File.WriteAllText("Questions.json", jsonString);
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
    }
}
