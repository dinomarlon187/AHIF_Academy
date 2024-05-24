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
        public string FalseAnswer { get; set; }


        public TextInput(string text, string subject, string answer, string falseAnswer)
        {
            Text = text;
            Subject = subject;
            CorrectAnswer = answer.Trim();
            FalseAnswer = falseAnswer;
        }
        public override void Draw(Grid grid)
        {
            grid.Children.Clear();
            TextBlock textBlock = new TextBlock()
            {
                Text = Text,
                FontSize = 20,
                TextWrapping = System.Windows.TextWrapping.Wrap,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            Grid.SetColumn(textBlock, 0);
            Grid.SetRow(textBlock, 0);
            Grid.SetColumnSpan(textBlock, 3);


            RichTextBox textBox = new RichTextBox()
            {
                Width = 400,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };
            textBox.Document.Blocks.Clear();
            textBox.Document.Blocks.Add(new Paragraph(new Run(FalseAnswer)));
            Grid.SetColumn(textBox, 0);
            Grid.SetRow(textBox, 1);
            Grid.SetColumnSpan(textBox, 3);


            Button submit = new Button()
            {
                Height = 50,
                Width = 100,
                Content = "Submit"
            };
            Grid.SetColumn(submit, 1);
            Grid.SetRow(submit, 2);

            submit.Click += Submit_Click;
            grid.Children.Add(textBlock);
            grid.Children.Add(textBox);
            grid.Children.Add(submit);
        }

        private void Submit_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            if (sender is Button button)
            {
                Grid grid = (Grid)button.Parent;
                RichTextBox textBox = (RichTextBox)grid.Children[1];
                TextRange textRange = new TextRange(
                textBox.Document.ContentStart,
                textBox.Document.ContentEnd
                );
                string userAnswer = textRange.Text.Trim();
                if (userAnswer == "")
                {
                    userAnswer = "²";
                    textBox.AppendText(" ");
                }
                if (CorrectAnswer.Length - userAnswer.Length > 10 || userAnswer.Length - CorrectAnswer.Length > 10)
                {
                    MessageBox.Show("Hör auf reinzutrollen.");
                }
                else
                {
                    button.IsEnabled = false;
                    textBox.IsReadOnly = true;
                    if (CheckAnswer(userAnswer))
                    {
                        textBox.Background = System.Windows.Media.Brushes.Green;
                    }
                    else
                    {


                        TextPointer target = textBox.Document.ContentStart;
                        target = target.GetPositionAtOffset(2, LogicalDirection.Forward);
                        TextRange range;
                        int idx = 0;
                        char letter = '²';
                        if (CorrectAnswer.Length > userAnswer.Length)
                        {
                            for (int i = 0; i < CorrectAnswer.Length - userAnswer.Length; i++)
                            {
                                textBox.AppendText(" ");
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
                }






                
                    

                        
                    
                    

                


            }

            
        }
    }
}
