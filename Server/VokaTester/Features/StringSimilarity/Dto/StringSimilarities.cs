namespace VokaTester.Features.StringSimilarity.Dto
{
    using System.Collections.Generic;
    using VokaTester.Features.StringSimilarity.Dto.Levensthein;

    public class StringSimilarities
    {
        public double Dist_Metric_Damerau { get; set; }
        
        public double LongestCommonSubsequence { get; set; }
        
        public double Distance_JaroWinkler { get; set; }
        
        public double Similarity_JaroWinkler { get; set; }
        
        public int Subsequence_LongestCommonSubsequenceLength { get; set; }

        public double Dist_norm_NGram { get; set; }
        
        public double OptimalStringAlignment { get; set; }
    }
}
