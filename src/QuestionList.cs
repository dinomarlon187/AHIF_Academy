﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ahif_academy
{
    class QuestionList
    {
        private List<Question> questions = new List<Question>();

        public string CurrentSubject { get; set; }

        public void DeserializeFromJSON()
        {
            string jsonString = System.IO.File.ReadAllText("Questions.json");
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonString);
            foreach (var question in jsonObj)
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
        public Question GetRandomQuestion()
        {
            Random random = new Random();
            int index = random.Next(questions.Count);
            return questions[index];
        }

    }
}