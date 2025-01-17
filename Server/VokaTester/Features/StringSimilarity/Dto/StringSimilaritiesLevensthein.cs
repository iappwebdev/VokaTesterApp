﻿namespace VokaTester.Features.StringSimilarity.Dto
{
    using System.Collections.Generic;
    using VokaTester.Features.StringSimilarity.Dto.Levensthein;

    public class StringSimilaritiesLevenshtein
    {
        public double Dist_Levenshtein { get; set; }
        
        public double Dist_Normalized_Levenshtein { get; set; }
        
        public double Similiarity_NormalizedLevenshtein { get; set; }
        
        public double Dist_Weighted { get; set; }
        
        public double Dist_WeightedA { get; set; }
        
        public double Dist_WeightedC { get; set; }
        
        public double Dist_WeightedE { get; set; }
        
        public double Dist_WeightedI { get; set; }
        
        public double Dist_WeightedO { get; internal set; }

        public double Dist_WeightedU { get; set; }
        
        public List<EditOperation> LevenstheinMethod { get; set; }
    }
}
