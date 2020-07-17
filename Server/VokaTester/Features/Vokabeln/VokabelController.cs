namespace VokaTester.Features.Vokabeln
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.Vokabeln.Models;

    [Authorize]
    public class VokabelController : ApiController
    {
        private readonly IVokabelService vokabelService;

        public VokabelController(IVokabelService vokabelService)
        {
            this.vokabelService = vokabelService;
        }

        [HttpGet]
        public async Task<IEnumerable<VokabelListResponseModel>> GetByLektion() => await this.vokabelService.ByLektion(1);

        [HttpGet]
        public async Task<VokabelDetailsResponseModel> Details()
        {

        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVokabelRequestModel model)
        {
            int id = await this.vokabelService.Create(model.Frz, model.Deu, 1);

            return Created(nameof(this.Create), id);
        }
    }
}
