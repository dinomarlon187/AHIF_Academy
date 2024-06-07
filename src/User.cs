﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace ahif_academy
{
    public class User
    {
        public string filepathuser = "../../../JSONFiles/profiles.json";
        public string Username { get; set; }
        public string Password { get; set; }
        public string Profilpicture { get; set; }
        public QuestionList Questions { get; set; } = new QuestionList();


        public int QuestionsAnsweredCorrect 
        {
            get
            {
                return QuestionsAnsweredCorrectDeutsch+QuestionsAnsweredCorrectMathe;
            }
        }

        public int QuestionsAnsweredIncorrect 
        {
            get
            {
                return QuestionsAnsweredIncorrectDeutsch+QuestionsAnsweredIncorrectMathe;
            }
        }
        public int QuestionsAnsweredIncorrectDeutsch { get; set; }
        public int QuestionsAnsweredCorrectDeutsch { get; set; }
        public int QuestionsAnsweredIncorrectMathe { get; set; }
        public int QuestionsAnsweredCorrectMathe { get; set; }

        public void StatisticsDraw(string subject, Canvas canvas)
        {
            canvas.Children.Clear();
            double height = canvas.ActualHeight;
            double width = canvas.ActualWidth-20;
            if (subject.ToLower() == "deutsch" || subject.ToLower() == "mathe")
            {
                System.Windows.Shapes.Rectangle barCorrect = new System.Windows.Shapes.Rectangle
                {
                    Fill = Brushes.Blue,
                    Height = height/3,
                    Stroke = Brushes.Black
                };
                System.Windows.Shapes.Rectangle barIncorrect = new System.Windows.Shapes.Rectangle
                {
                    Fill = Brushes.Red,
                    Height = height/3,
                    Stroke = Brushes.Black
                };
                Label labelCorrect = new Label()
                {
                    Height = height/3-10,
                    FontSize = 30

                };
                Label labelIncorrect = new Label()
                {
                    Height = height / 3 - 10,
                    FontSize = 30
                };
                int correct = 0;
                int incorrect = 0;
                if (subject.ToLower() == "deutsch")
                {
                    correct = QuestionsAnsweredCorrectDeutsch;
                    incorrect = QuestionsAnsweredIncorrectDeutsch;
                }
                else if (subject.ToLower() == "mathe")
                {
                    correct = QuestionsAnsweredCorrectMathe;
                    incorrect = QuestionsAnsweredIncorrectMathe;
                }
                barCorrect.Width = width / (correct + incorrect) * correct;
                barIncorrect.Width = width - barCorrect.Width;

                
                
                

                
                Canvas.SetTop(barIncorrect, height / 2 - barCorrect.Height / 2);
                Canvas.SetLeft(barIncorrect,20+ width - barIncorrect.Width);
                canvas.Children.Add(barIncorrect);

                Canvas.SetTop(barCorrect, height / 2 - barCorrect.Height / 2);
                Canvas.SetLeft(barCorrect, 20);
                canvas.Children.Add(barCorrect);

                if (correct != 0)
                {
                    labelCorrect.Content = $"{correct} Fragen, {Math.Round((double)correct / ((double)correct + (double)incorrect) * 100)}%";
                    Canvas.SetLeft(labelCorrect, 20);
                    Canvas.SetTop(labelCorrect, height / 2 - labelCorrect.Height / 2);
                    canvas.Children.Add(labelCorrect);
                }
                if (incorrect != 0)
                {
                    labelIncorrect.Content = $"{incorrect} Fragen, {Math.Round((double)incorrect / ((double)incorrect + (double)correct) * 100)}%";
                    Canvas.SetLeft(labelIncorrect, width - barIncorrect.Width+ 20);
                    Canvas.SetTop(labelIncorrect, height / 2 - labelCorrect.Height / 2);
                    canvas.Children.Add(labelIncorrect);
                }
            }
            else if (subject.ToLower() == "allgemein")
            {
                
            }

            


        }

    }
}
