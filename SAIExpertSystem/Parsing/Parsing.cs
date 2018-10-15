using System;
using System.Text.RegularExpressions;

namespace SAIExpertSystem.Parsing
{
    public class Parsing
    {
        int firstSpacePosition;
        int secondSpacePosition;
        string[] probs;

        public KnowledgeBase knowledgeBase = new KnowledgeBase();
        
        public KnowledgeBase Parse(string[] mkb)
        {
            
            for (int i = 0; i < mkb.Length; i++)
            {
                if (string.IsNullOrEmpty(mkb[i]))
                {
                    firstSpacePosition = i;
                    break;
                }
            }

            for (int spacePosition = firstSpacePosition; spacePosition < mkb.Length; spacePosition++)
            {
                if (string.IsNullOrEmpty(mkb[spacePosition]))
                {
                    secondSpacePosition = spacePosition;
                }
            }

            for (int i = 0; i < firstSpacePosition; i++)
            {
                knowledgeBase.header.Add(mkb[i]);
            }

            for (int i = firstSpacePosition+2; i < secondSpacePosition; i++)
            {
                knowledgeBase.questions.Add(mkb[i]);
            }

            for (int i = secondSpacePosition + 1; i < mkb.Length; i++)
            {
                string hypothese = mkb[i];
                hypothese = Regex.Replace(hypothese, "[0-9,.]", "").Trim();
                Hypothesis hyp = new Hypothesis();
                hyp.name = hypothese;

                string aprioryProb = mkb[i];
                aprioryProb = Regex.Replace(aprioryProb, "[А-ЯЁа-яё-]", "").Trim().Remove(0, 1);
                probs = aprioryProb.Split(',');
                hyp.aprioriProbability = Convert.ToDouble(probs[0].Replace(".", ","));

                for (int k = 1; k < probs.Length; k += 3)
                {
                    Probabilities probability = new Probabilities();
                    probability.number = Convert.ToInt16(probs[k].Trim());
                    probability.probIncrease = Convert.ToDouble(probs[k + 1].Replace(".", ","));
                    probability.probDecrease = Convert.ToDouble(probs[k + 2].Replace(".", ","));
                    hyp.probabilities.Add(probability);
                }
                knowledgeBase.calcData.Add(hyp);                
            }
            return knowledgeBase;
        }
    }
}