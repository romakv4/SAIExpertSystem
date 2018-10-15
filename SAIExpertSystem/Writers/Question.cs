using System;
using System.Windows.Forms;
using SAIExpertSystem.Parsing;

namespace SAIExpertSystem.Writers
{
    public class Question
    {
        public Tuple<bool, bool> Current(bool isButtonsActive, bool isStarted, TextBox currentQuestionTextBox, int questionCount, KnowledgeBase knowledgeBase)
        {
            if (questionCount < knowledgeBase.questions.Count)
            {
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount];
            }
            else
            {
                currentQuestionTextBox.Text = knowledgeBase.questions[questionCount - 1];
                currentQuestionTextBox.ResetText();
                isButtonsActive = true;
                isStarted = false;
                MessageBox.Show("Консультация завершена.");
            }

            return Tuple.Create(isButtonsActive, isStarted);
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