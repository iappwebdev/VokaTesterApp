namespace VokaTester.Features.StringSimilarity
{
    using VokaTester.Features.StringSimilarity.Dto;

    public interface IStringSimilarityService
    {
        SimilarityResult CheckSimilarity(string truth, string answer);
    }
}
