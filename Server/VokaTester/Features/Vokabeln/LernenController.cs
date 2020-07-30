namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.Vokabeln.Models;

    //[Authorize]
    public class LernenController : ApiController
    {
        private readonly IVokabelService vokabelService;

        public LernenController(IVokabelService vokabelService)
        {
            this.vokabelService = vokabelService;
        }

        [Route("lektionen/{lektionId}")]
        [HttpGet]
        public async Task<LektionListingServiceModel> GetLektion(int lektionId)
            => await this.vokabelService.Lektion(lektionId);

        [Route("lektionen")]
        [HttpGet]
        public async Task<IEnumerable<LektionListingServiceModel>> GetLektionen()
            => await this.vokabelService.Lektionen();

        [Route("vokabeln-by-lektion/{lektionId}")]
        [HttpGet]
        public async Task<IEnumerable<VokabelListingServiceModel>> GetByLektion(int lektionId)
            => await this.vokabelService.ByLektion(lektionId);

        [Route("wortnetz/{wortnetzId}")]
        [HttpGet]
        public async Task<IEnumerable<VokabelListingServiceModel>> GetByWortnetz(string wortnetz)
            => await this.vokabelService.ByWortnetz(wortnetz);
    }
}
