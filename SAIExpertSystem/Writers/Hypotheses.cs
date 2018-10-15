using System;
using System.Windows.Forms;
using SAIExpertSystem.Parsing;

namespace SAIExpertSystem.Writers
{
    public class Hypotheses
    {
        public void WriteHypotheses(TextBox hypothesesTextBox, KnowledgeBase knowledgeBase)
        {
            for (int i = 0; i < knowledgeBase.calcData.Count; i++)
            {
                String name = knowledgeBase.calcData[i].name;
                String prob = knowledgeBase.calcData[i].aprioriProbability.ToString("N5");
                hypothesesTextBox.AppendText(name + " " + prob + Environment.NewLine);
            }
        }
    }
}