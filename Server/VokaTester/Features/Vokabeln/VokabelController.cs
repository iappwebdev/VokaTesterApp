namespace VokaTester.Features.Vokabeln
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.Vokabeln.Models;

    public class VokabelController : ApiController
    {
        private readonly IVokabelService vokabelService;

        public VokabelController(IVokabelService vokabelService)
        {
            this.vokabelService = vokabelService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVokabelRequestModel model)
        {
            int id = await this.vokabelService.Create(model.Frz, model.Deu, 1);

            return Created(nameof(this.Create), id);
        }
    }
}
