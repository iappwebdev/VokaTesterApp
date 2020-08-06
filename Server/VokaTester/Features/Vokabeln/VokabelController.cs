namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.Vokabeln.Dto;

    using static VokaTester.Infrastructure.WebConstants;

    [Authorize]
    [Route("api/vokabeln")]
    public class VokabelController : ApiController
    {
        private readonly IVokabelService vokabelService;

        public VokabelController(IVokabelService vokabelService)
        {
            this.vokabelService = vokabelService;
        }

        [Route(Id)]
        [HttpGet]
        public async Task<VokabelDto> Single(int id)
            => await this.vokabelService.SingleAsync(id);

        [HttpGet]
        public async Task<IEnumerable<VokabelDto>> All()
            => await this.vokabelService.AllAsync();

        [Route("by-lektion/{lektionId}")]
        [HttpGet]
        public async Task<IEnumerable<VokabelDto>> ByLektion(int lektionId)
            => await this.vokabelService.ByLektionAsync(lektionId);

        //[Route("by-wortnetz/{wortnetzId}")]
        //[HttpGet]
        //public async Task<IEnumerable<VokabelDto>> ByWortnetz(string wortnetz)
        //    => await this.vokabelService.ByWortnetzAsync(wortnetz);

        [Route("previous-by-similarity")]
        [HttpGet]
        public async Task<IEnumerable<VokabelDto>> PreviousBySimilarity(int vokabelId, string pattern)
            => await this.vokabelService.PreviousBySimilarity(vokabelId, pattern);
    }
}
