namespace VokaTester.Features.StringSimilarity
{
    using VokaTester.Features.StringSimilarity.Models;

    public interface IStringSimilarityService
    {
        SimilarityResult CheckSimilarity(string truth, string answer);
    }
}
