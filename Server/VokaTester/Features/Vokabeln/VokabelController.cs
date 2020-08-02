namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.Vokabeln.Dto;

    using static VokaTester.Infrastructure.WebConstants;

    //[Authorize]
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
            => await this.vokabelService.Single(id);

        [HttpGet]
        public async Task<IEnumerable<VokabelDto>> All()
            => await this.vokabelService.All();

        [Route("by-lektion/{lektionId}")]
        [HttpGet]
        public async Task<IEnumerable<VokabelDto>> ByLektion(int lektionId)
            => await this.vokabelService.ByLektion(lektionId);

        [Route("by-wortnetz/{wortnetzId}")]
        [HttpGet]
        public async Task<IEnumerable<VokabelDto>> ByWortnetz(string wortnetz)
            => await this.vokabelService.ByWortnetz(wortnetz);

        //[Route(Id)]
        //[HttpGet]
        //public async Task<VokabelDetailsServiceModel> Details(int id)
        //    => await this.vokabelService.Details(id);

        //[HttpPost]
        //public async Task<ActionResult<int>> Create(CreateVokabelModel model)
        //{
        //    int id = await this.vokabelService.Create(model.Frz, model.Deu, 1);

        //    return Created(nameof(this.Create), id);
        //}
    }
}
