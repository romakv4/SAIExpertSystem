using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SAIExpertSystem.Parsing;
using SAIExpertSystem.Recalculating;
using SAIExpertSystem.Writers;

namespace SAIExpertSystem
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private string[] mkb;
        private KnowledgeBase knowledgeBase;
        private int questionCount;
        private bool isStarted;
        private bool isButtonsActive;
        Recalculate recalc = new Recalculate();
        Question questionWriter = new Question();
        Hypotheses hypothesesWriter = new Hypotheses();

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                headerTextBox.ResetText();
                questionTextBox.ResetText();
                hypothesesTextBox.ResetText();
                var parsing = new Parsing.Parsing();
                var mkbFile = openFileDialog.FileName;
                string ext = Path.GetExtension(mkbFile);
                
                if (ext == ".mkb")
                {

                    knowledgeBase = parsing.Parse(File.ReadAllLines(mkbFile, Encoding.GetEncoding(1251)));
                    var header = knowledgeBase.header;
                    var questions = knowledgeBase.questions;
                    var calcData = knowledgeBase.calcData;
                    for (int i = 0; i < header.Count; i++)
                    {
                        headerTextBox.AppendText(header[i] + Environment.NewLine);
                    }

                    for (int i = 0; i < questions.Count; i++)
                    {
                        questionTextBox.AppendText(questions[i] + Environment.NewLine);
                    }

                    for (int i = 0; i < calcData.Count; i++)
                    {
                        hypothesesTextBox.AppendText(calcData[i].name + " " + calcData[i].aprioriProbability + Environment.NewLine);
                    }

                    startButton.Enabled = true;
                    stopButton.Enabled = true;
                }
                else
                {
                    headerTextBox.ResetText();
                    questionTextBox.ResetText();
                    hypothesesTextBox.ResetText();
                    MessageBox.Show("Файл должен быть в формате mkb");
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (headerTextBox.Text == "")
            {
                MessageBox.Show("Для начала консультации загрузите базу знаний.");
            }
            else
            {
                questionCount = 0;
                isStarted = true;
                isButtonsActive = false;

                isButtonsActive = questionWriter.Current(isButtonsActive, isStarted, currentQuestionTextBox, questionCount, knowledgeBase).Item1;
                isStarted = questionWriter.Current(isButtonsActive, isStarted, currentQuestionTextBox, questionCount, knowledgeBase).Item2;
                ButtonSwitcher(isButtonsActive, isStarted);
                questionCount++;
                questionWriter.All(questionTextBox, questionCount, knowledgeBase);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (headerTextBox.Text == "")
            {
                MessageBox.Show("Консультация не была начата.");
            }
            else
            {
                isButtonsActive = true;
                isStarted = false;
                ButtonSwitcher(isButtonsActive, isStarted);

                questionCount = 0;
                headerTextBox.ResetText();
                questionTextBox.ResetText();
                hypothesesTextBox.ResetText();
                currentQuestionTextBox.ResetText();
                MessageBox.Show("Консультация была отменена.");
            }
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            hypothesesTextBox.ResetText();
            String currQuestion = currentQuestionTextBox.Text;

            knowledgeBase = recalc.No(currQuestion, knowledgeBase);

            Tuple<bool, bool > flags = questionWriter.Current(isButtonsActive, isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
            isButtonsActive = flags.Item1;
            isStarted = flags.Item2;
            ButtonSwitcher(isButtonsActive, isStarted);
            questionCount++;

            questionWriter.All(questionTextBox, questionCount, knowledgeBase);
            
            hypothesesWriter.WriteHypotheses(hypothesesTextBox, knowledgeBase);
        }

        private void moreNoButton_Click(object sender, EventArgs e)
        {
            hypothesesTextBox.ResetText();
            String currQuestion = currentQuestionTextBox.Text;

            knowledgeBase = recalc.MoreNo(currQuestion, knowledgeBase);

            Tuple<bool, bool> flags = questionWriter.Current(isButtonsActive, isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
            isButtonsActive = flags.Item1;
            ButtonSwitcher(isButtonsActive, isStarted);
            isStarted = flags.Item2;
            questionCount++;

            questionWriter.All(questionTextBox, questionCount, knowledgeBase);

            hypothesesWriter.WriteHypotheses(hypothesesTextBox, knowledgeBase);
        }

        private void dunnoButton_Click(object sender, EventArgs e)
        {
            hypothesesTextBox.ResetText();

            knowledgeBase = recalc.Dunno(knowledgeBase);

            Tuple<bool, bool> flags = questionWriter.Current(isButtonsActive, isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
            isButtonsActive = flags.Item1;
            isStarted = flags.Item2;
            ButtonSwitcher(isButtonsActive, isStarted);
            questionCount++;

            questionWriter.All(questionTextBox, questionCount, knowledgeBase);

            hypothesesWriter.WriteHypotheses(hypothesesTextBox, knowledgeBase);
        }

        private void moreYesButton_Click(object sender, EventArgs e)
        {
            hypothesesTextBox.ResetText();
            String currQuestion = currentQuestionTextBox.Text;

            knowledgeBase = recalc.MoreYes(currQuestion, knowledgeBase);

            Tuple<bool, bool> flags = questionWriter.Current(isButtonsActive, isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
            isButtonsActive = flags.Item1;
            isStarted = flags.Item2;
            ButtonSwitcher(isButtonsActive, isStarted);
            questionCount++;

            questionWriter.All(questionTextBox, questionCount, knowledgeBase);

            hypothesesWriter.WriteHypotheses(hypothesesTextBox, knowledgeBase);

        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            hypothesesTextBox.ResetText();
            String currQuestion = currentQuestionTextBox.Text;

            knowledgeBase = recalc.Yes(currQuestion, knowledgeBase);

            Tuple<bool, bool> flags = questionWriter.Current(isButtonsActive, isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
            isButtonsActive = flags.Item1;
            isStarted = flags.Item2;
            ButtonSwitcher(isButtonsActive, isStarted);
            questionCount++;

            questionWriter.All(questionTextBox, questionCount, knowledgeBase);

            hypothesesWriter.WriteHypotheses(hypothesesTextBox, knowledgeBase);
        }

        private void ButtonSwitcher(bool isButtonsActive, bool isStarted)
        {
            if (isStarted)
            {
                startButton.Enabled = false;
            }
            else
            {
                startButton.Enabled = false;
                stopButton.Enabled = false;
            }

            if (isButtonsActive)
            {
                noButton.Enabled = false;
                moreNoButton.Enabled = false;
                dunnoButton.Enabled = false;
                moreYesButton.Enabled = false;
                yesButton.Enabled = false;
            }
            else
            {
                noButton.Enabled = true;
                moreNoButton.Enabled = true;
                dunnoButton.Enabled = true;
                moreYesButton.Enabled = true;
                yesButton.Enabled = true;
            }
        }
    }
}
