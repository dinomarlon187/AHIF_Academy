using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ahif_academy
{
    /// <summary>
    /// Interaction logic for WindowAddQuestion.xaml
    /// </summary>
    public partial class WindowAddQuestion : Window
    {
        public WindowAddQuestion(string questionType)
        {
            InitializeComponent();
            ComboBox cb = new ComboBox();
            cb.Items.Add("Mathe");
            cb.Items.Add("Deutsch");
            cb.SelectedIndex = 0;
            cb.Width = 200;
            cb.Height = 30;
            Canvas.SetTop(cb, 90);
            Canvas.SetLeft(cb, 140);
            canvas.Children.Add(cb);
            InitWindow(questionType, new string[]{ "", "", "", "", "", "", "" });
        }

        public WindowAddQuestion(Question question)
        {
            InitializeComponent();
            TextBlockHeader.Text = "Bearbeite die vorhandene Frage:";
            string questionType = "";
            string[] textBoxTexts = new string[] {};
            if (question is YesNo)
            {
                questionType = "yesno";
                textBoxTexts = new string[] { question.Text, ((YesNo)question).CorrectAnswer };
            }
            else if (question is MultipleChoice)
            {
                questionType = "multiplechoice";
                textBoxTexts = new string[] { question.Text, ((MultipleChoice)question).CorrectAnswer, ((MultipleChoice)question).Answers[0], ((MultipleChoice)question).Answers[1], ((MultipleChoice)question).Answers[2], ((MultipleChoice)question).Answers[3] };
            }
            else if (question is TextInput)
            {
                questionType = "textinput";
                textBoxTexts = new string[] { question.Text, ((TextInput)question).CorrectAnswer, ((TextInput)question).FalseAnswer };
            }
            InitWindow(questionType, textBoxTexts);
            
        }
        private void InitWindow(string questionType, string[] textBoxTexts)
        {

            if (questionType.ToLower() == "yesno")
            {
                AddNewInput(2, new string[] { "Frage", "Richtige Antwort" }, textBoxTexts);
            }
            else if (questionType.ToLower() == "multiplechoice")
            {
                AddNewInput(6, new string[] { "Frage", "Richtige Antwort", "Antwort 1", "Antwort 2", "Antwort 3", "Antwort 4" }, textBoxTexts);
            }
            else if (questionType.ToLower() == "textinput")
            {
                AddNewInput(3, new string[] { "Frage", "Richtige Antwort", "Falsche Antwort" }, textBoxTexts);
            }
        }
        private void AddNewInput(int amount, string[] textBlockTexts, string[] textBoxTexts)
        {
            
            int positionY = 130;
            for (int i = 0; i < amount; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = textBlockTexts[i];
                textBlock.Width = 100;
                textBlock.Height = 30;
                Canvas.SetTop(textBlock, positionY + i*50+10);
                Canvas.SetLeft(textBlock, 10);
                canvas.Children.Add(textBlock);

                TextBox tb = new TextBox();
                tb.Width = 300;
                tb.Height = 40;
                tb.TextWrapping = TextWrapping.Wrap;
                tb.Text = textBoxTexts[i];
                tb.Name = "textBox" + i;
                Canvas.SetTop(tb, positionY + i*50);
                Canvas.SetLeft(tb, 140);
                canvas.Children.Add(tb);
            }
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}