namespace VokaTester.Features.VokabelSpellCheck.Models
{
    using System.Collections.Generic;
    using VokaTester.Features.StringSimilarity.Models;

    public class VokabelSpellCheckResult
    {
        public int VokabelId { get; internal set; }

        public string Answer { get; internal set; }
        
        public bool IsCorrect { get; set; }

        public bool HasMultipleCorrectAnswers { get; set; }
        
        public List<string> FurtherCorrectAnswers { get; set; }
        
        public string Truth { get; set; }
        
        public string TruthSanitized { get; set; }
        
        public List<string> FurtherCorrectAnswersSanitized { get; set; }
     
        public string AnswerSanitized { get; internal set; }

        public SimilarityResult SimilarityResult { get; set; }
    }
}
