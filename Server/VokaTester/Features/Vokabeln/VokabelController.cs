namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.Vokabeln.Models;

    using static VokaTester.Infrastructure.WebConstants;

    //[Authorize]
    public class VokabelController : ApiController
    {
        private readonly IVokabelService vokabelService;

        public VokabelController(IVokabelService vokabelService)
        {
            this.vokabelService = vokabelService;
        }

        [HttpGet]
        public async Task<IEnumerable<VokabelListingServiceModel>> GetByLektion()
            => await this.vokabelService.ByLektion(1);

        [Route(Id)]
        [HttpGet]
        public async Task<VokabelDetailsServiceModel> Details(int id)
            => await this.vokabelService.Details(id);

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVokabelModel model)
        {
            int id = await this.vokabelService.Create(model.Frz, model.Deu, 1);

            return Created(nameof(this.Create), id);
        }
    }
}
