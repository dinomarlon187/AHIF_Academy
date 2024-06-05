using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ahif_academy
{
    public class TextInput : Question
    {
        [JsonProperty]
        public string WrongAnswer { get; set; }

        Button submit = new Button()
        {
            Height = 50,
            Width = 100,
            Content = "Submit"
        };

        RichTextBox textBoxAnswer = new RichTextBox()
        {
            Width = 400,
            HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            VerticalAlignment = System.Windows.VerticalAlignment.Center
        };
        public TextInput(string text, string subject, string answer, string wrongAnswer)
        {
            Text = text;
            Subject = subject;
            CorrectAnswer = answer.Trim();
            WrongAnswer = wrongAnswer;
            textblockQuestion.Text = Text;
            Type = "TextInput";
        }
        public override void Draw(Grid grid)
        {
            grid.Children.Clear();
            Grid.SetColumn(textblockQuestion, 0);
            Grid.SetRow(textblockQuestion, 0);
            Grid.SetColumnSpan(textblockQuestion, 3);
            textBoxAnswer.Document.Blocks.Clear();
            textBoxAnswer.Document.Blocks.Add(new Paragraph(new Run(WrongAnswer)));
            Grid.SetColumn(textBoxAnswer, 0);
            Grid.SetRow(textBoxAnswer, 1);
            Grid.SetColumnSpan(textBoxAnswer, 3);
            Grid.SetColumn(submit, 1);
            Grid.SetRow(submit, 2);
            submit.Click += Submit_Click;
            submit.IsEnabled = true;
            grid.Children.Add(textblockQuestion);
            grid.Children.Add(textBoxAnswer);
            grid.Children.Add(submit);
            grid.Children.Add(btnNextQuestion);
            
        }
        public override object Copy()
        {
            TextInput question = new TextInput(Text, Subject, CorrectAnswer, WrongAnswer);
            question.btnNextQuestion = btnNextQuestion;
            question.textblockQuestion = textblockQuestion;
            return question;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                Grid grid = (Grid)button.Parent;
                
                TextRange textRange = new TextRange(
                textBoxAnswer.Document.ContentStart,
                textBoxAnswer.Document.ContentEnd
                );
                string userAnswer = textRange.Text.Trim();
                if (userAnswer == "")
                {
                    userAnswer = "²";
                    textBoxAnswer.AppendText(" ");
                }
                if (CorrectAnswer.Length - userAnswer.Length > 10 || userAnswer.Length - CorrectAnswer.Length > 10)
                {
                    MessageBox.Show("Hör auf reinzutrollen.");
                }
                else
                {
                    button.IsEnabled = false;
                    textBoxAnswer.IsReadOnly = true;
                    if (CheckAnswer(userAnswer))
                    {
                        textBoxAnswer.Background = System.Windows.Media.Brushes.Green;
                    }
                    else
                    {


                        TextPointer target = textBoxAnswer.Document.ContentStart;
                        target = target.GetPositionAtOffset(2, LogicalDirection.Forward);
                        TextRange range;
                        int idx = 0;
                        char letter = '²';
                        if (CorrectAnswer.Length > userAnswer.Length)
                        {
                            for (int i = 0; i < CorrectAnswer.Length - userAnswer.Length; i++)
                            {
                                textBoxAnswer.AppendText(" ");
                            }
                        }
                        else if (CorrectAnswer.Length < userAnswer.Length)
                        {
                            int length = CorrectAnswer.Length;
                            for (int i = 0; i < length - 1; i++)
                            {
                                CorrectAnswer += " ";
                            }

                        }
                        {

                        }
                        while (true)
                        {


                            try
                            {
                                range = new TextRange(target, target.GetPositionAtOffset(1, LogicalDirection.Forward));
                            }
                            catch (Exception)
                            {
                                break;
                            }



                            if (range.IsEmpty == false)
                            {
                                try
                                {
                                    letter = Convert.ToChar(range.Text);
                                }
                                catch
                                {
                                    break;
                                }
                                if (letter != CorrectAnswer[idx])
                                {
                                    range.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Red);

                                }
                                idx++;

                            }
                            target = target.GetPositionAtOffset(1, LogicalDirection.Forward);

                      
                        }
                        
                    }
                    btnNextQuestion.IsEnabled = true;
                    btnNextQuestion.Visibility = Visibility.Visible;

                }
            }

            
        }
        public override string ToString()
        {
            return $"Subject: {Subject}, Text: {Text},Richtige Antwort: {CorrectAnswer}, Falsche Antwort: {WrongAnswer}";
        }
    }
}
