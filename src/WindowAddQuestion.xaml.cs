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
        public object question = null;
        string[] textBoxTexts = new string[] { "", "", "", "", "", "", "" };
        string questionType = "";
        ComboBox cbQuestionType = new ComboBox();
        ComboBox cb = new ComboBox();
        Canvas canvasDraw;
        TextBlock textBlockHead;
        Button buttonOK;
        public WindowAddQuestion()
        {
            InitializeComponent();
            Log.log.Information("Fenster zum Hinzufügen einer Frage geöffnet");
            canvasDraw = canvas;
            buttonOK = ButtonOK;
            textBlockHead = TextBlockHeader;
            cbQuestionType.Items.Add("MultipleChoice");
            cbQuestionType.Items.Add("YesNo");
            cbQuestionType.Items.Add("TextInput");
            cbQuestionType.SelectedIndex = 0;
            cbQuestionType.Width = 200;
            cbQuestionType.Height = 30;
            cbQuestionType.SelectionChanged += CbQuestionType_SelectionChanged;
            Canvas.SetTop(cbQuestionType, 90);
            Canvas.SetLeft(cbQuestionType, 100);            
            cb.Items.Add("Mathe");
            cb.Items.Add("Deutsch");
            cb.SelectedIndex = 0;
            cb.Width = 200;
            cb.Height = 30;
            Canvas.SetTop(cb, 90);
            Canvas.SetLeft(cb, 340);
            questionType = (string)cbQuestionType.SelectedItem;
            InitWindow(questionType, textBoxTexts);
        }

        private void CbQuestionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            textBoxTexts = new string[]{ textBoxTexts[0], textBoxTexts[1], "", "", "", "" };
            InitWindow((string)cbQuestionType.SelectedItem, textBoxTexts);
        }

        public WindowAddQuestion(Question question)
        {
            InitializeComponent();
            Log.log.Information("Fenster zum Editieren einer Frage geöffnet");

            canvasDraw = canvas;
            buttonOK = ButtonOK;
            textBlockHead = TextBlockHeader;
            textBlockHead.Text = "Bearbeite die vorhandene Frage:";

            cbQuestionType.Items.Add("MultipleChoice");
            cbQuestionType.Items.Add("YesNo");
            cbQuestionType.Items.Add("TextInput");
            cbQuestionType.SelectedItem = question.Type;
            cbQuestionType.Width = 200;
            cbQuestionType.Height = 30;
            cbQuestionType.SelectionChanged += CbQuestionType_SelectionChanged;
            Canvas.SetTop(cbQuestionType, 90);
            Canvas.SetLeft(cbQuestionType, 100);

            cb.Items.Add("Mathe");
            cb.Items.Add("Deutsch");
            cb.SelectedIndex = 0;
            cb.Width = 200;
            cb.Height = 30;
            cb.SelectedItem = question.Subject;
            Canvas.SetTop(cb, 90);
            Canvas.SetLeft(cb, 340);

            string questionType = "";
            
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
                textBoxTexts = new string[] { question.Text, ((TextInput)question).CorrectAnswer, ((TextInput)question).WrongAnswer };
            }
            InitWindow(questionType, textBoxTexts);
            
        }
        private void InitWindow(string questionType, string[] textBoxTexts)
        {
            canvasDraw.Children.Clear();
            canvasDraw.Children.Add(textBlockHead);
            canvasDraw.Children.Add(cb);
            canvasDraw.Children.Add(cbQuestionType);
            canvasDraw.Children.Add(buttonOK);

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
                tb.TextChanged += Tb_TextChanged;
                Canvas.SetTop(tb, positionY + i*50);
                Canvas.SetLeft(tb, 140);
                canvas.Children.Add(tb);
            }
        }

        private void Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                int index = Convert.ToInt16(tb.Name.Substring(7));
                textBoxTexts[index] = tb.Text;
            }
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {  
            if ((string)cbQuestionType.SelectedItem == "MultipleChoice" && textBoxTexts[0] != "" && textBoxTexts[2] != "" && textBoxTexts[3] != "" && textBoxTexts[4] != "" && textBoxTexts[5] != "" && textBoxTexts[1] != "")
            {
                question = new MultipleChoice(textBoxTexts[0], textBoxTexts[2], textBoxTexts[3], textBoxTexts[4], textBoxTexts[5], textBoxTexts[1], (string)cb.SelectedItem);
                DialogResult = true;
            }
            else if ((string)cbQuestionType.SelectedItem == "YesNo" && textBoxTexts[0] != "" && textBoxTexts[1] != "")
            {
                if (textBoxTexts[1].ToLower() == "yes" || textBoxTexts[1].ToLower() == "no")
                {
                    question = new YesNo(textBoxTexts[0], (string)cb.SelectedItem, textBoxTexts[1]);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Die Antwort muss entweder 'yes' oder 'no' sein.");
                    Log.log.Warning("Versuch, eine Yes/No Frage mit einer ungültigen Antwort hinzuzufügen");
                }
            }
            else if ((string)cbQuestionType.SelectedItem == "TextInput" && textBoxTexts[0] != "" && textBoxTexts[1] != "" && textBoxTexts[2] != "")
            {
                question = new TextInput(textBoxTexts[0], (string)cb.SelectedItem, textBoxTexts[1], textBoxTexts[2]);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Bitte gib überall einen Wert ein!");
                Log.log.Warning("Versuch, eine Frage mit fehlenden Variablen hinzuzufügen");
            }
        }
    }
}