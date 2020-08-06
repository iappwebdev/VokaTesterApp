namespace VokaTester.Features.VokabelSpellCheck.Dto
{
    using System.Collections.Generic;
    using VokaTester.Features.StringSimilarity.Dto;

    public class CheckVokabelResponse
    {
        public int VokabelId { get; set; }

        public bool IsCorrect { get; set; }

        public bool IsSimilar => this.SimilarityResult?.IsAnswerSimilar ?? false;

        public string Truth { get; set; }
        
        public string Answer { get; set; }
        
        public string TruthSan { get; set; }

        public string AnswerSan { get; set; }

        public string TruthArticle { get; set; }

        public string AnswerArticle { get; set; }

        public bool IsArtikelFehler => string.Compare(this.TruthArticle, this.AnswerArticle) != 0;

        public bool HasMultipleCorrectAnswers { get; set; }

        public List<int> FurtherCorrectVokabelIds { get; set; }

        public List<string> FurtherCorrectAnswers { get; set; }
        
        public List<string> FurtherCorrectAnswersSan { get; set; }

        public SimilarityResult SimilarityResult { get; set; }
        
    }
}
