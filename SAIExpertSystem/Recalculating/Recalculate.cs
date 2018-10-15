using System;
using System.Linq;
using SAIExpertSystem.Parsing;

namespace SAIExpertSystem.Recalculating
{
    public class Recalculate
    {
        public KnowledgeBase No(String currentQuestion, KnowledgeBase knowledgeBase)
        {
            
            for (int i = 0; i < knowledgeBase.calcData.Count; i++)
            {
                double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestion)].probIncrease;
                double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestion)].probDecrease;

                double aprProb = ((1 - probIncrease) * aprioryProb) /
                                ((1 - probIncrease) * aprioryProb + (1 - probDecrease) * (1 - aprioryProb));

                knowledgeBase.calcData[i].aprioriProbability = aprProb;
            }
            knowledgeBase.calcData = knowledgeBase.calcData.OrderByDescending(h => h.aprioriProbability).ToList();
            return knowledgeBase;
        }

        public KnowledgeBase MoreNo(String currentQuestion, KnowledgeBase knowledgeBase)
        {
            for (int i = 0; i < knowledgeBase.calcData.Count; i++)
            {
                double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestion)].probIncrease;
                double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestion)].probDecrease;

                double no = ((1 - probIncrease) * aprioryProb) /
                              ((1 - probIncrease) * aprioryProb + (1 - probDecrease) * (1 - aprioryProb));
                double aprProb = no + (((0.25) * (aprioryProb - no)) / (0.5));

                knowledgeBase.calcData[i].aprioriProbability = aprProb;
            }
            knowledgeBase.calcData = knowledgeBase.calcData.OrderByDescending(h => h.aprioriProbability).ToList();
            return knowledgeBase;
        }

        public KnowledgeBase Dunno(KnowledgeBase knowledgeBase)
        {
            for (int i = 0; i < knowledgeBase.calcData.Count; i++)
            {
                double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                double aprProb = aprioryProb;

                knowledgeBase.calcData[i].aprioriProbability = aprProb;
            }
            knowledgeBase.calcData = knowledgeBase.calcData.OrderByDescending(h => h.aprioriProbability).ToList();
            return knowledgeBase;
        }

        public KnowledgeBase MoreYes(String currentQuestion, KnowledgeBase knowledgeBase)
        {
            for (int i = 0; i < knowledgeBase.calcData.Count; i++)
            {
                double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestion)].probIncrease;
                double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestion)].probDecrease;

                double yes = ((1 - probIncrease) * aprioryProb) /
                              ((1 - probIncrease) * aprioryProb + (1 - probDecrease) * (1 - aprioryProb));
                double aprProb = aprioryProb + (((0.25) * (yes - aprioryProb)) / (0.5));

                knowledgeBase.calcData[i].aprioriProbability = aprProb;
            }
            knowledgeBase.calcData = knowledgeBase.calcData.OrderByDescending(h => h.aprioriProbability).ToList();
            return knowledgeBase;
        }

        public KnowledgeBase Yes(String currentQuestion, KnowledgeBase knowledgeBase)
        {
            for (int i = 0; i < knowledgeBase.calcData.Count; i++)
            {
                double aprioryProb = knowledgeBase.calcData[i].aprioriProbability;
                double probIncrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestion)].probIncrease;
                double probDecrease = knowledgeBase.calcData[i].probabilities[knowledgeBase.questions.IndexOf(currentQuestion)].probDecrease;

                double aprProb = (probIncrease * aprioryProb) / (
                                  (probIncrease * aprioryProb) + (probDecrease * (1 - aprioryProb)));

                knowledgeBase.calcData[i].aprioriProbability = aprProb;
            }
            knowledgeBase.calcData = knowledgeBase.calcData.OrderByDescending(h => h.aprioriProbability).ToList();
            return knowledgeBase;
        }
    }
}