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
            => await this.fortschrittService.SingleAsync(lektionId);

        [Route("reset/{lektionId}")]
        [HttpPost]
        public async Task<int> ResetFortschritt(int lektionId)
           => await this.fortschrittService.ResetAsync(lektionId);
    }
}
