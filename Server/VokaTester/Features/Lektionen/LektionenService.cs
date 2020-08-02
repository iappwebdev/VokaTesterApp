namespace VokaTester.Features.Lektionen
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.Lektionen.Dto;

    public class LektionenService : ILektionenService
    {
        private readonly VokaTesterDbContext dbContext;
        private readonly IMapper mapper;

        public LektionenService(
            VokaTesterDbContext dbContext,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LektionDto>> All()
            => await this.dbContext
                .Lektion
                .Select(x => this.mapper.Map<LektionDto>(x))
                .ToListAsync();
        
        public async Task<LektionDto> Single(int lektionId)
        {
            Lektion res =
                await this.dbContext
                   .Lektion
                   .FirstOrDefaultAsync(x => x.Id == lektionId);

            return this.mapper.Map<LektionDto>(res);
        }

    }
}
