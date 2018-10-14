using System.Collections.Generic;

namespace SAIExpertSystem.Parsing
{
    public class Hypothese
    {
        public string name;
        public double aprioriProbability;
        public List<Probabilities> probabilities = new List<Probabilities>();
    }
}