using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SAIExpertSystem.Parsing;

namespace SAIExpertSystem
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private string[] mkb;
        private KnowledgeBase knowledgeBase;
        private int questionCount = 0;
        private bool isStarted = false;

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
                        headerTextBox.AppendText(header[i] + "\n");
                    }

                    for (int i = 0; i < questions.Count; i++)
                    {
                        questionTextBox.AppendText(questions[i] + "\n");
                    }

                    for (int i = 0; i < calcData.Count; i++)
                    {
                        hypothesesTextBox.AppendText(calcData[i].name + " " + calcData[i].aprioriProbability + "\n");
                    }
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
                    noButton.Visible = true;
                    moreNoButton.Visible = true;
                    dunnoButton.Visible = true;
                    moreYesButton.Visible = true;
                    yesButton.Visible = true;

                    var questions = knowledgeBase.questions;
                    currentQuestionTextBox.Text = questions[questionCount];
                    questionTextBox.Text = "";
                    isStarted = true;
                    questionCount++;
                    for (int i = questionCount; i < questions.Count; i++)
                    {
                        questionTextBox.AppendText(questions[i] + "\n");
                    }
                }
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
            if (questionCount < knowledgeBase.questions.Count)
            {
                hypothesesTextBox.ResetText();
                for (int i = 0; i < knowledgeBase.calcData.Count; i++)
                {
                    double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                    double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probIncrease;
                    double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probDecrease;

                    double aprProb = ((1 - probIncrease) * aprioryProb) /
                                  ((1 - probIncrease) * aprioryProb + (1 - probDecrease) * (1 - aprioryProb));

                    knowledgeBase.calcData[i].aprioriProbability = aprProb;
                    String name = knowledgeBase.calcData[i].name;
                    String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                    hypothesesTextBox.AppendText(name + " " + prob + "\n");
                }
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount];
                questionTextBox.Text = "";
                questionCount++;
                for (int j = questionCount; j < knowledgeBase.questions.Count; j++)
                {
                    questionTextBox.AppendText(knowledgeBase.questions[j] + "\n");
                }
            }
            else
            {
                hypothesesTextBox.ResetText();
                for (int i = 0; i < knowledgeBase.calcData.Count; i++)
                {
                    double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                    double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probIncrease;
                    double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probDecrease;

                    double aprProb = ((1 - probIncrease) * aprioryProb) /
                                  ((1 - probIncrease) * aprioryProb + (1 - probDecrease) * (1 - aprioryProb));

                    knowledgeBase.calcData[i].aprioriProbability = aprProb;
                    String name = knowledgeBase.calcData[i].name;
                    String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                    hypothesesTextBox.AppendText(name + " " + prob + "\n");
                }
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount-1];
                questionTextBox.Text = "";
                questionCount++;
                for (int j = questionCount; j < knowledgeBase.questions.Count; j++)
                {
                    questionTextBox.AppendText(knowledgeBase.questions[j] + "\n");
                }
                currentQuestionTextBox.ResetText();
                isStarted = false;
                questionCount = 0;
                MessageBox.Show("Консультация завершена.");
            }
        }

        private void moreNoButton_Click(object sender, EventArgs e)
        {
            if (questionCount < knowledgeBase.questions.Count)
            {
                hypothesesTextBox.ResetText();
                for (int i = 0; i < knowledgeBase.calcData.Count; i++)
                {
                    double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                    double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probIncrease;
                    double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probDecrease;

                    double no = ((1 - probIncrease) * aprioryProb) /
                                  ((1 - probIncrease) * aprioryProb + (1 - probDecrease) * (1 - aprioryProb));
                    double aprProb = no + (((0.25) * (aprioryProb - no)) / (0.5));

                    knowledgeBase.calcData[i].aprioriProbability = aprProb;
                    String name = knowledgeBase.calcData[i].name;
                    String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                    hypothesesTextBox.AppendText(name + " " + prob + "\n");
                }
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount];
                questionTextBox.Text = "";
                questionCount++;
                for (int j = questionCount; j < knowledgeBase.questions.Count; j++)
                {
                    questionTextBox.AppendText(knowledgeBase.questions[j] + "\n");
                }
            }
            else
            {
                hypothesesTextBox.ResetText();
                for (int i = 0; i < knowledgeBase.calcData.Count; i++)
                {
                    double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                    double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probIncrease;
                    double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probDecrease;

                    double no = ((1 - probIncrease) * aprioryProb) /
                                  ((1 - probIncrease) * aprioryProb + (1 - probDecrease) * (1 - aprioryProb));
                    double aprProb = no + (((0.25) * (aprioryProb - no)) / (0.5));

                    knowledgeBase.calcData[i].aprioriProbability = aprProb;
                    String name = knowledgeBase.calcData[i].name;
                    String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                    hypothesesTextBox.AppendText(name + " " + prob + "\n");
                }
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount-1];
                questionTextBox.Text = "";
                questionCount++;
                for (int j = questionCount; j < knowledgeBase.questions.Count; j++)
                {
                    questionTextBox.AppendText(knowledgeBase.questions[j] + "\n");
                }
                currentQuestionTextBox.ResetText();
                isStarted = false;
                questionCount = 0;
                MessageBox.Show("Консультация завершена.");
            }
        }

        private void dunnoButton_Click(object sender, EventArgs e)
        {
            if (questionCount < knowledgeBase.questions.Count)
            {
                hypothesesTextBox.ResetText();
                for (int i = 0; i < knowledgeBase.calcData.Count; i++)
                {
                    double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                    double aprProb = aprioryProb;

                    knowledgeBase.calcData[i].aprioriProbability = aprProb;
                    String name = knowledgeBase.calcData[i].name;
                    String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                    hypothesesTextBox.AppendText(name + " " + prob + "\n");
                }
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount];
                questionTextBox.Text = "";
                questionCount++;
                for (int j = questionCount; j < knowledgeBase.questions.Count; j++)
                {
                    questionTextBox.AppendText(knowledgeBase.questions[j] + "\n");
                }
            }
            else
            {
                hypothesesTextBox.ResetText();
                for (int i = 0; i < knowledgeBase.calcData.Count; i++)
                {
                    double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                    double aprProb = aprioryProb;

                    knowledgeBase.calcData[i].aprioriProbability = aprProb;
                    String name = knowledgeBase.calcData[i].name;
                    String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                    hypothesesTextBox.AppendText(name + " " + prob + "\n");
                }
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount-1];
                questionTextBox.Text = "";
                questionCount++;
                for (int j = questionCount; j < knowledgeBase.questions.Count; j++)
                {
                    questionTextBox.AppendText(knowledgeBase.questions[j] + "\n");
                }
                currentQuestionTextBox.ResetText();
                isStarted = false;
                questionCount = 0;
                MessageBox.Show("Консультация завершена.");
            }
        }

        private void moreYesButton_Click(object sender, EventArgs e)
        {
            if (questionCount < knowledgeBase.questions.Count)
            {
                hypothesesTextBox.ResetText();
                for (int i = 0; i < knowledgeBase.calcData.Count; i++)
                {
                    double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                    double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probIncrease;
                    double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probDecrease;

                    double yes = ((1 - probIncrease) * aprioryProb) /
                                  ((1 - probIncrease) * aprioryProb + (1 - probDecrease) * (1 - aprioryProb));
                    double aprProb = aprioryProb + (((0.25) * (yes - aprioryProb)) / (0.5));

                    knowledgeBase.calcData[i].aprioriProbability = aprProb;
                    String name = knowledgeBase.calcData[i].name;
                    String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                    hypothesesTextBox.AppendText(name + " " + prob + "\n");
                }
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount];
                questionTextBox.Text = "";
                questionCount++;
                for (int j = questionCount; j < knowledgeBase.questions.Count; j++)
                {
                    questionTextBox.AppendText(knowledgeBase.questions[j] + "\n");
                }
            }
            else
            {
                hypothesesTextBox.ResetText();
                for (int i = 0; i < knowledgeBase.calcData.Count; i++)
                {
                    double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                    double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probIncrease;
                    double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probDecrease;

                    double yes = (probIncrease * aprioryProb) / (
                                  (probIncrease * aprioryProb) + (probDecrease * (1 - aprioryProb)));
                    double aprProb = aprioryProb + (((0.25) * (yes - aprioryProb)) / (0.5));

                    knowledgeBase.calcData[i].aprioriProbability = aprProb;
                    String name = knowledgeBase.calcData[i].name;
                    String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                    hypothesesTextBox.AppendText(name + " " + prob + "\n");
                }
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount-1];
                questionTextBox.Text = "";
                questionCount++;
                for (int j = questionCount; j < knowledgeBase.questions.Count; j++)
                {
                    questionTextBox.AppendText(knowledgeBase.questions[j] + "\n");
                }
                currentQuestionTextBox.ResetText();
                isStarted = false;
                questionCount = 0;
                MessageBox.Show("Консультация завершена.");
            }
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            if (questionCount < knowledgeBase.questions.Count)
            {
                hypothesesTextBox.ResetText();
                for (int i = 0; i < knowledgeBase.calcData.Count; i++)
                {
                    Console.WriteLine(knowledgeBase.calcData[i].name);
                    Console.WriteLine(knowledgeBase.calcData[i].aprioriProbability);
                    Console.WriteLine(knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probIncrease);
                    Console.WriteLine(knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probDecrease);
                    double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                    double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probIncrease;
                    double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probDecrease;

                    double aprProb = (probIncrease * aprioryProb) / (
                                      (probIncrease * aprioryProb) + (probDecrease * (1 - aprioryProb)));

                    knowledgeBase.calcData[i].aprioriProbability = aprProb;
                    String name = knowledgeBase.calcData[i].name;
                    String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                    hypothesesTextBox.AppendText(name + " " + prob + "\n");
                }
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount];
                questionTextBox.Text = "";
                questionCount++;
                for (int j = questionCount; j < knowledgeBase.questions.Count; j++)
                {
                    questionTextBox.AppendText(knowledgeBase.questions[j] + "\n");
                }
            }
            else
            {
                hypothesesTextBox.ResetText();
                for (int i = 0; i < knowledgeBase.calcData.Count; i++)
                {
                    double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                    double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probIncrease;
                    double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestionTextBox.Text)].probDecrease;

                    double aprProb = (probIncrease * aprioryProb) / (
                                      (probIncrease * aprioryProb) + (probDecrease * (1 - aprioryProb)));

                    knowledgeBase.calcData[i].aprioriProbability = aprProb;
                    String name = knowledgeBase.calcData[i].name;
                    String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                    hypothesesTextBox.AppendText(name + " " + prob + "\n");
                }
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount-1];
                questionTextBox.Text = "";
                questionCount++;
                for (int j = questionCount; j < knowledgeBase.questions.Count; j++)
                {
                    questionTextBox.AppendText(knowledgeBase.questions[j] + "\n");
                }
                currentQuestionTextBox.ResetText();
                isStarted = false;
                questionCount = 0;
                MessageBox.Show("Консультация завершена.");
            }
        }
    }
}
