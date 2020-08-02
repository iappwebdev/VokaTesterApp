namespace VokaTester.Features.VokabelSpellCheck.Dto
{
    using System.Collections.Generic;
    using VokaTester.Features.StringSimilarity.Dto;

    public class CheckVokabelResponse
    {
        public int VokabelId { get; internal set; }

        public bool IsCorrect { get; set; }

        public string Truth { get; set; }
        
        public string Answer { get; internal set; }
        
        public string TruthSan { get; set; }

        public string AnswerSan { get; internal set; }

        public bool HasMultipleCorrectAnswers { get; set; }

        public List<int> FurterCorrectVokabelIds { get; internal set; }

        public List<string> FurtherCorrectAnswers { get; set; }
        
        public List<string> FurtherCorrectAnswersSan { get; set; }

        public SimilarityResult SimilarityResult { get; set; }
    }
}
