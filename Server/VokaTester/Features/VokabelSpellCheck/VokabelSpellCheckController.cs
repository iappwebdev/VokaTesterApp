namespace VokaTester.Features.VokabelSpellCheck
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.VokabelSpellCheck.Dto;

    [Authorize]
    [Route("api/trainieren")]
    public class VokabelSpellCheckController : ApiController
    {
        private readonly IVokabelSpellCheckService vokabelSpellCheckService;

        public VokabelSpellCheckController(
            IVokabelSpellCheckService vokabelSpellCheckService)
        {
            this.vokabelSpellCheckService = vokabelSpellCheckService;
        }

        [HttpPost]
        public async Task<CheckVokabelResponse> CheckSpelling(CheckVokabelRequest model)
            => await this.vokabelSpellCheckService.CheckSpellingAsync(model.VokabelId, model.Answer, model.IsPrevVokabel);
    }
}
