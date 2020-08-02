namespace VokaTester.Features.VokabelSpellCheck
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.VokabelSpellCheck.Dto;
    using VokaTester.Infrastructure.Services;

    //[Authorize]
    [Route("api/trainieren")]
    public class VokabelSpellCheckController : ApiController
    {
        private readonly IVokabelSpellCheckService vokabelSpellCheckService;
        private readonly ICurrentUserService currentUser;

        public VokabelSpellCheckController(
            IVokabelSpellCheckService vokabelSpellCheckService,
            ICurrentUserService currentUser)
        {
            this.vokabelSpellCheckService = vokabelSpellCheckService;
            this.currentUser = currentUser;
        }

        [HttpPost]
        public async Task<CheckVokabelResponse> CheckSpelling(CheckVokabelRequest model)
            => await this.vokabelSpellCheckService.CheckSpelling(model.VokabelId, model.Answer);
    }
}
