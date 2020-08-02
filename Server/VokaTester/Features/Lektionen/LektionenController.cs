﻿namespace VokaTester.Features.Lektionen
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.Lektionen.Dto;

    using static VokaTester.Infrastructure.WebConstants;

    //[Authorize]
    [Route("api/lektionen")]
    public class LektionenController : ApiController
    {
        private readonly ILektionenService vokabelService;

        public LektionenController(ILektionenService vokabelService)
        {
            this.vokabelService = vokabelService;
        }

        [Route(Id)]
        [HttpGet]
        public async Task<LektionDto> Lektion(int id)
            => await this.vokabelService.Single(id);

        [HttpGet]
        public async Task<IEnumerable<LektionDto>> Lektionen()
            => await this.vokabelService.All();
    }
}
