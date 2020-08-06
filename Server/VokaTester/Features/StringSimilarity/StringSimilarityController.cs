namespace VokaTester.Features.StringSimilarity
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.StringSimilarity.Dto;
    using VokaTester.Infrastructure.Services;

    [Authorize]
    [Route("api/string-similarity")]
    public class StringSimilarityController : ApiController
    {
        private readonly IStringSimilarityService stringSimilarityService;

        public StringSimilarityController(
            IStringSimilarityService stringSimilarityService)
        {
            this.stringSimilarityService = stringSimilarityService;
        }

        [HttpGet]
        public SimilarityResult CheckSpelling(string truth, string answer)
            => this.stringSimilarityService.CheckSimilarity(truth, answer);

    }
}
