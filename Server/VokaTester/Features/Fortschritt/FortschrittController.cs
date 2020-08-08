namespace VokaTester.Features.Fortschritt
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.Fortschritt.Dto;

    [Authorize]
    [Route("api/fortschritt")]
    public class FortschrittController : ApiController
    {
        private readonly IFortschrittService fortschrittService;

        public FortschrittController(
            IFortschrittService fortschrittService)
        {
            this.fortschrittService = fortschrittService;
        }

        [Route("{lektionId}")]
        [HttpGet]
        public async Task<FortschrittDto> ByLektion(int lektionId)
            => await this.fortschrittService.ByLektionAsync(lektionId);

        [Route("{lektionId}/bereich/{bereichId}")]
        [HttpGet]
        public async Task<FortschrittDto> ByLektionBereich(int lektionId, int bereichId)
            => await this.fortschrittService.ByLektionBereichAsync(lektionId, bereichId);

        [HttpPost]
        [Route("finish/{lektionId}")]
        public async Task<int> FinishLektion(int lektionId)
            => await this.fortschrittService.FinishLektionAsync(lektionId);

        [HttpPost]
        [Route("finish/{lektionId}/bereich/{bereichId}")]
        public async Task<int> FinishBereich(int lektionId, int bereichId)
            => await this.fortschrittService.FinishLektionBereichAsync(lektionId, bereichId);

        [Route("reset/{lektionId}")]
        [HttpPost]
        public async Task<int> ResetFortschrittLektion(int lektionId)
           => await this.fortschrittService.ResetLektionAsync(lektionId);

        [Route("reset/{lektionId}/bereich/{bereichId}")]
        [HttpPost]
        public async Task<int> ResetFortschrittBereich(int lektionId, int bereichId)
           => await this.fortschrittService.ResetLektionBereichAsync(lektionId, bereichId);
    }
}
