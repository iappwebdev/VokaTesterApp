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

        [Route("lektion/{lektionId}")]
        [HttpGet]
        public async Task<IEnumerable<VokabelDto>> ByLektion(int lektionId)
            => await this.vokabelService.ByLektionAsync(lektionId);

        [Route("lektion/{lektionId}/bereich/{bereichId}")]
        [HttpGet]
        public async Task<IEnumerable<VokabelDto>> ByLektionBereich(int lektionId, int bereichId)
            => await this.vokabelService.ByLektionBereichAsync(lektionId, bereichId);

        [Route("previous-with-similarity")]
        [HttpPost]
        public async Task<IEnumerable<VokabelDto>> PreviousBySimilarity(SimilarityRequestDto dto)
            => await this.vokabelService.PreviousBySimilarity(dto.VokabelId, dto.Pattern, dto.Prev, dto.Next);
    }
}
