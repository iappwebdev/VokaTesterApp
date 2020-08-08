namespace VokaTester.Features.StringSimilarity
{
    using VokaTester.Features.StringSimilarity.Dto;

    public interface IGeneralizeStringService
    {
        string SanitizeString(string dirtyString);

        ArticleInfo GetArticleInfo(string frz);

        char? GetPrevChar(string value, int pos);

        char? GetNextChar(string value, int pos);
    }
}
