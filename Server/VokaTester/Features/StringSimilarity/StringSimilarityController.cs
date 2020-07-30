namespace VokaTester.Features.StringSimilarity
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.StringSimilarity.Models;
    using VokaTester.Features.VokabelSpellCheck.Models;
    using VokaTester.Infrastructure.Services;

    //[Authorize]
    public class StringSimilarityController : ApiController
    {
        private readonly IStringSimilarityService stringSimilarityService;
        private readonly ICurrentUserService currentUser;

        public StringSimilarityController(
            IStringSimilarityService stringSimilarityService,
            ICurrentUserService currentUser)
        {
            this.stringSimilarityService = stringSimilarityService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public SimilarityResult CheckSpelling(string truth, string answer)
            => this.stringSimilarityService.CheckSimilarity(truth, answer);

    }
}
