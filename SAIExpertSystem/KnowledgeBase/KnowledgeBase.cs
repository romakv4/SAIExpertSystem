﻿using System.Collections.Generic;

namespace SAIExpertSystem.Parsing
{
    public class KnowledgeBase
    {
        public List<string> header = new List<string>();
        public List<string> questions = new List<string>();
        public List<Hypothesis> calcData = new List<Hypothesis>();
    }
}