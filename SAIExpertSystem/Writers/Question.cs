using System;
using System.Windows.Forms;
using SAIExpertSystem.Parsing;

namespace SAIExpertSystem.Writers
{
    public class Question
    {
        public bool Current(bool isStarted, TextBox currentQuestionTextBox, int questionCount, KnowledgeBase knowledgeBase)
        {
            if (questionCount < knowledgeBase.questions.Count)
            {
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount];
            }
            else
            {
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount - 1];
                currentQuestionTextBox.ResetText();
                isStarted = false;
                MessageBox.Show("Консультация завершена.");
            }

            return isStarted;
        }

        public void All(TextBox questionTextBox, int questionCount, KnowledgeBase knowledgeBase)
        {
            questionTextBox.ResetText();

            for (int i = questionCount; i < knowledgeBase.questions.Count; i++)
            {
                questionTextBox.AppendText(knowledgeBase.questions[i] + Environment.NewLine);
            }
        }
    }
}