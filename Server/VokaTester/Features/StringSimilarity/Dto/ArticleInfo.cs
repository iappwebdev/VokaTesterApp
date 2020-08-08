namespace VokaTester.Features.StringSimilarity.Dto
{
    public class ArticleInfo
    {
        public string Word { get; set; }

        public string PossibleArticle { get; set; }

        public bool HasPossibleArticle => !string.IsNullOrWhiteSpace(this.PossibleArticle);

        public bool HasArticle => this.IsMasc || this.IsFem;

        public string Article { get; set; }

        public bool IsMasc { get; set; }

        public bool IsFem { get; set; }
    }
}
