using System;
using System.IO;
using System.Linq;
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
            if (isStarted)
            {
                MessageBox.Show("Пожалуйста, завершите или отмените текущую консультацию.");
            }
            else
            {
                if (headerTextBox.Text == "")
                {
                    MessageBox.Show("Для начала консультации загрузите базу знаний.");
                }
                else
                {
                    questionCount = 0;
                    isStarted = true;

                    noButton.Visible = true;
                    moreNoButton.Visible = true;
                    dunnoButton.Visible = true;
                    moreYesButton.Visible = true;
                    yesButton.Visible = true;

                    isStarted = questionWriter.Current(isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
                    questionCount++;
                    questionWriter.All(questionTextBox, questionCount, knowledgeBase);
                }
                Console.WriteLine(questionTextBox.Text);
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
                noButton.Visible = false;
                moreNoButton.Visible = false;
                dunnoButton.Visible = false;
                moreYesButton.Visible = false;
                yesButton.Visible = false;

                isStarted = false;
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

            isStarted = questionWriter.Current(isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
            questionCount++;

            questionWriter.All(questionTextBox, questionCount, knowledgeBase);
            
            hypothesesWriter.WriteHypotheses(hypothesesTextBox, knowledgeBase);
        }

        private void moreNoButton_Click(object sender, EventArgs e)
        {
            hypothesesTextBox.ResetText();
            String currQuestion = currentQuestionTextBox.Text;

            knowledgeBase = recalc.MoreNo(currQuestion, knowledgeBase);

            isStarted = questionWriter.Current(isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
            questionCount++;

            questionWriter.All(questionTextBox, questionCount, knowledgeBase);

            hypothesesWriter.WriteHypotheses(hypothesesTextBox, knowledgeBase);
        }

        private void dunnoButton_Click(object sender, EventArgs e)
        {
            hypothesesTextBox.ResetText();

            knowledgeBase = recalc.Dunno(knowledgeBase);

            isStarted = questionWriter.Current(isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
            questionCount++;

            questionWriter.All(questionTextBox, questionCount, knowledgeBase);

            hypothesesWriter.WriteHypotheses(hypothesesTextBox, knowledgeBase);
        }

        private void moreYesButton_Click(object sender, EventArgs e)
        {
            hypothesesTextBox.ResetText();
            String currQuestion = currentQuestionTextBox.Text;

            knowledgeBase = recalc.MoreYes(currQuestion, knowledgeBase);

            isStarted = questionWriter.Current(isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
            questionCount++;

            questionWriter.All(questionTextBox, questionCount, knowledgeBase);

            hypothesesWriter.WriteHypotheses(hypothesesTextBox, knowledgeBase);

        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            hypothesesTextBox.ResetText();
            String currQuestion = currentQuestionTextBox.Text;

            knowledgeBase = recalc.Yes(currQuestion, knowledgeBase);

            isStarted = questionWriter.Current(isStarted, currentQuestionTextBox, questionCount, knowledgeBase);
            questionCount++;

            questionWriter.All(questionTextBox, questionCount, knowledgeBase);

            hypothesesWriter.WriteHypotheses(hypothesesTextBox, knowledgeBase);
        }
    }
}
