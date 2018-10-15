using System.Collections.Generic;

namespace SAIExpertSystem.Parsing
{
    public class Hypothesis
    {
        public string name;
        public double aprioriProbability;
        public List<Probabilities> probabilities = new List<Probabilities>();
    }
}