﻿namespace VokaTester.Features.StringSimilarity.Models
{
    public class SimilarityResult
    {
        public string Truth { get; set; }

        public string Answer { get; set; }

        public bool IsAnswerEqual => string.Compare(this.Truth, this.Answer) == 0;

        public bool IsAnswerSimilar => this.StringSimilaritiesLevenshtein?.Dist_Weighted < 1;

        public bool IsAnswerSimilarA => this.StringSimilaritiesLevenshtein?.Dist_WeightedA < 1;

        public bool IsAnswerSimilarC => this.StringSimilaritiesLevenshtein?.Dist_WeightedC < 1;

        public bool IsAnswerSimilarE => this.StringSimilaritiesLevenshtein?.Dist_WeightedE < 1;
        
        public bool IsAnswerSimilarI => this.StringSimilaritiesLevenshtein?.Dist_WeightedI < 1;

        public bool IsAnswerSimilarU => this.StringSimilaritiesLevenshtein?.Dist_WeightedU < 1;

        public StringSimilaritiesLevenshtein StringSimilaritiesLevenshtein { get; set; }
        
        public StringSimilarities StringSimilarities { get; set; }
        
        public int NumWrongCharsTruth => this.Truth.Length - this.StringSimilarities?.Subsequence_LongestCommonSubsequenceLength ?? 0;
        
        public int NumWrongCharsAnswer => this.Answer.Length - this.StringSimilarities?.Subsequence_LongestCommonSubsequenceLength ?? 0;
    }
}
