namespace VokaTester.Features.StringSimilarity
{
    public interface IGeneralizeStringService
    {
        string SanitizeString(string dirtyString);

        bool HasArticle(string frz, out string article, out string word);
    }
}
