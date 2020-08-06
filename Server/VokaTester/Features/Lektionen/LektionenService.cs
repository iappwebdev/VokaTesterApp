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
    using VokaTester.Infrastructure.Services;

    public class LektionenService : ILektionenService
    {
        private readonly VokaTesterDbContext dbContext;
        private readonly ICurrentUserService currentUserService;
        private readonly IMapper mapper;

        public LektionenService(
            VokaTesterDbContext dbContext,
            ICurrentUserService currentUserService,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.currentUserService = currentUserService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LektionDto>> AllAsync()
        {
            List<Lektion> lektionen = await this.dbContext
                .Lektion
                .ToListAsync();

            List<LektionDto> results = lektionen.Select(x => this.mapper.Map<LektionDto>(x)).ToList();

            foreach (LektionDto res in results)
            {
                Lektion lektion = lektionen.First(x => x.Id == res.Id);
                this.SetFortschritt(lektion, res);
            }

            return results;
        }
        
        
        public async Task<LektionDto> SingleAsync(int lektionId)
        {
            Lektion lektion =
                await this.dbContext
                   .Lektion
                   .FirstOrDefaultAsync(x => x.Id == lektionId);

            LektionDto res = this.mapper.Map<LektionDto>(lektion);
            this.SetFortschritt(lektion, res);

            return res;
        }

        private void SetFortschritt(Lektion lektion, LektionDto res)
        {
            Fortschritt fortschritt =
                lektion.Fortschritte
                .FirstOrDefault(x => x.UserId == this.currentUserService.GetId());

            if (fortschritt != null)
            {
                res.IsStarted = true;
                res.IsCompleted = fortschritt.Durchlauf > 1;
            }
        }
    }
}
