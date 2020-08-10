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

        //[Route("lektion")]
        [HttpPost]
        public async Task<CheckVokabelResponse> CheckSpellingVokabel(CheckVokabelRequest model)
            => await this.vokabelSpellCheckService.CheckSpellingVokabelAsync(model.VokabelId, model.Answer, model.IsPrevVokabel, model.IsBereich);

        //[Route("lektion-bereich")]
        //[HttpPost]
        //public async Task<CheckVokabelResponse> CheckSpellingBereich(CheckVokabelRequest model)
        //    => await this.vokabelSpellCheckService.CheckSpellingVokabelAsync(model.VokabelId, model.Answer, model.IsPrevVokabel, true);
    }
}
