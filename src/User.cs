using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using Newtonsoft.Json;

namespace ahif_academy
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class User
    {
        [JsonProperty]
        public string filepathuser = "../../../JSONFiles/profiles.json";
        [JsonProperty]
        public string Username { get; set; }
        [JsonProperty]
        public string Password { get; set; }
        [JsonProperty]
        public string Profilpicture { get; set; }
        public QuestionList Questions { get; set; } = new QuestionList();
        SolidColorBrush Blue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7AB2B2"));
        SolidColorBrush Red = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FA7070"));


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
        [JsonProperty]
        public int QuestionsAnsweredIncorrectDeutsch { get; set; }
        [JsonProperty]
        public int QuestionsAnsweredCorrectDeutsch { get; set; }
        [JsonProperty]
        public int QuestionsAnsweredIncorrectMathe { get; set; }
        [JsonProperty]
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
                    Fill = Blue,
                    Height = height/4,
                    RadiusX = 10,
                    RadiusY = 10,
                    Stroke = Brushes.Black
                };
                System.Windows.Shapes.Rectangle barIncorrect = new System.Windows.Shapes.Rectangle
                {
                    Fill = Red,
                    Height = height/4,
                    RadiusX = 10,
                    RadiusY = 10,
                    Stroke = Brushes.Black
                };
                Label labelCorrect = new Label()
                {
                    Height = height/3-10,
                    FontSize = 25

                };
                Label labelIncorrect = new Label()
                {
                    Height = height / 3 - 10,
                    FontSize = 25
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
                    Canvas.SetTop(labelCorrect, height / 2 - barCorrect.Height / 2 + barCorrect.Height);
                    canvas.Children.Add(labelCorrect);
                }
                if (incorrect != 0)
                {
                    labelIncorrect.Content = $"{incorrect} Fragen, {Math.Round((double)incorrect / ((double)incorrect + (double)correct) * 100)}%";
                    Canvas.SetRight(labelIncorrect, 0);
                    Canvas.SetTop(labelIncorrect, height / 2 - barCorrect.Height / 2 + barCorrect.Height);
                    canvas.Children.Add(labelIncorrect);
                }
            }
            else if (subject.ToLower() == "allgemein")
            {
                for (int i = 0; i < 3; i++)
                {
                    System.Windows.Shapes.Rectangle barCorrect = new System.Windows.Shapes.Rectangle
                    {
                        Fill = Blue,
                        Height = height / 7,
                        RadiusX = 10,
                        RadiusY = 10,
                        Stroke = Brushes.Black
                    };
                    System.Windows.Shapes.Rectangle barIncorrect = new System.Windows.Shapes.Rectangle
                    {
                        Fill = Red,
                        Height = height / 7,
                        RadiusX = 10,
                        RadiusY = 10,
                        Stroke = Brushes.Black
                    };
                    Label labelCorrect = new Label()
                    {
                        Height = height / 7 - 10,
                        FontSize = 20

                    };
                    Label labelIncorrect = new Label()
                    {
                        Height = height / 7 - 10,
                        FontSize = 20
                    };
                    Label header = new Label()
                    {
                        Height = height / 2 - 10,
                        Margin = new System.Windows.Thickness(0, 15, 0, 0),
                        FontSize = 20
                    };
                    int correct = 0;
                    int incorrect = 0;
                    if (i == 0)
                    {
                        correct = QuestionsAnsweredCorrectDeutsch;
                        incorrect = QuestionsAnsweredIncorrectDeutsch;
                        header.Content = "Deutsch:";
                    }
                    else if (i == 1)
                    {
                        correct = QuestionsAnsweredCorrectMathe;
                        incorrect = QuestionsAnsweredIncorrectMathe;
                        header.Content = "Mathe:";
                    }
                    else if (i == 2)
                    {
                        correct = QuestionsAnsweredCorrect;
                        incorrect = QuestionsAnsweredIncorrect;
                        header.Content = "Gesamt:";
                    }
                    barCorrect.Width = width / (correct + incorrect) * correct;
                    barIncorrect.Width = width - barCorrect.Width;

                    Canvas.SetTop(barIncorrect, height / 3 * i + height / 6 - barCorrect.Height / 2);
                    Canvas.SetLeft(barIncorrect, 20 + width - barIncorrect.Width);
                    canvas.Children.Add(barIncorrect);

                    Canvas.SetTop(barCorrect, height / 3 * i + height / 6 - barCorrect.Height / 2);
                    Canvas.SetLeft(barCorrect, 20);
                    canvas.Children.Add(barCorrect);

                    Canvas.SetTop(header, height / 3 * i-10);
                    Canvas.SetLeft(header, 20);
                    canvas.Children.Add(header);
                    if (correct != 0)
                    {
                        labelCorrect.Content = $"{correct} Fragen, {Math.Round((double)correct / ((double)correct + (double)incorrect) * 100)}%";
                        Canvas.SetLeft(labelCorrect, 20);
                        Canvas.SetTop(labelCorrect, height / 3 * i + height / 6 - barCorrect.Height / 2 + barCorrect.Height-5);
                        canvas.Children.Add(labelCorrect);
                    }
                    if (incorrect != 0)
                    {
                        labelIncorrect.Content = $"{incorrect} Fragen, {Math.Round((double)incorrect / ((double)incorrect + (double)correct) * 100)}%";
                        Canvas.SetRight(labelIncorrect,0);
                        Canvas.SetTop(labelIncorrect, height / 3 * i + height / 6 - barCorrect.Height / 2 + barCorrect.Height-5);
                        canvas.Children.Add(labelIncorrect);
                    }
                }
            }
            Log.log.Information("Statistik für User {UserManager.CurrentUser} gezeichnet");

            


        }

    }
}
