namespace VokaTester.Features.Fortschritt
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.Fortschritt.Dto;
    using VokaTester.Infrastructure.Services;

    public class FortschrittService : IFortschrittService
    {
        private readonly VokaTesterDbContext dbContext;
        private readonly ICurrentUserService currentUserService;
        private readonly IMapper mapper;

        public FortschrittService(
            VokaTesterDbContext dbContext,
            ICurrentUserService currentUserService,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.currentUserService = currentUserService;
            this.mapper = mapper;
        }

        public async Task<FortschrittDto> ByLektionAsync(int lektionId)
        {
            Fortschritt fortschritt =
                await this.dbContext
                    .Fortschritt
                    .FirstOrDefaultAsync(x =>
                        x.UserId == this.currentUserService.GetId()
                        && x.LektionId == lektionId
                        && !x.BereichId.HasValue);

            if (fortschritt == null)
            {
                Lektion lektion = await this.dbContext.Lektion.FirstAsync(x => x.Id == lektionId);

                return new FortschrittDto
                {
                    UserId = currentUserService.GetId(),
                    UserUserName = currentUserService.GetUserName(),
                    LektionId = lektion.Id,
                    LektionName = lektion.Name,
                    LetzteVokabelCorrectId = 0,
                    LetzteVokabelCorrectFrz = "N/A",
                    BereichId = null,
                    BereichName = null,
                    IsBeginning = true,
                };
            }

            return this.mapper.Map<FortschrittDto>(fortschritt);
        }

        public async Task<FortschrittDto> ByLektionBereichAsync(int lektionId, int bereichId)
        {
            Fortschritt fortschritt =
                await this.dbContext
                    .Fortschritt
                    .FirstOrDefaultAsync(x =>
                        x.UserId == this.currentUserService.GetId()
                        && x.LektionId == lektionId
                        && x.BereichId.HasValue
                        && x.BereichId.Value == bereichId);

            if (fortschritt == null)
            {
                Lektion lektion = await this.dbContext.Lektion.FirstAsync(x => x.Id == lektionId);
                List<Bereich> bereiche = lektion.Vokabeln.GroupBy(x => x.Bereich).Select(x => x.Key).ToList();
                Bereich bereich = bereiche.First(x => x.Id == bereichId);

                return new FortschrittDto
                {
                    UserId = currentUserService.GetId(),
                    UserUserName = currentUserService.GetUserName(),
                    LektionId = lektion.Id,
                    LektionName = lektion.Name,
                    LetzteVokabelCorrectId = 0,
                    LetzteVokabelCorrectFrz = "N/A",
                    BereichId = bereich.Id,
                    BereichName = bereich.Name,
                    IsBeginning = true,
                };
            }

            return this.mapper.Map<FortschrittDto>(fortschritt);
        }

        public async Task<int> FinishLektionAsync(int lektionId)
        {
            Fortschritt fortschritt =
                await this.dbContext
                   .Fortschritt
                    .FirstOrDefaultAsync(x =>
                        x.UserId == this.currentUserService.GetId()
                        && x.LektionId == lektionId
                        && !x.BereichId.HasValue);

            if (fortschritt != null)
            {
                fortschritt.Durchlauf++;
                fortschritt.LetzteVokabelCorrectId = null;
                fortschritt.LetzteVokabelWrongId = null;
            }

            return await this.dbContext.SaveChangesAsync();
        }

        public async Task<int> FinishLektionBereichAsync(int lektionId, int bereichId)
        {
            Fortschritt fortschritt =
                await this.dbContext
                    .Fortschritt
                    .FirstOrDefaultAsync(x =>
                        x.UserId == this.currentUserService.GetId()
                        && x.LektionId == lektionId
                        && x.BereichId.HasValue
                        && x.BereichId.Value == bereichId);

            if (fortschritt != null)
            {
                fortschritt.Durchlauf++;
                fortschritt.LetzteVokabelCorrectId = null;
                fortschritt.LetzteVokabelWrongId = null;
            }

            return await this.dbContext.SaveChangesAsync();
        }

        public async Task<int> ResetLektionAsync(int lektionId)
        {
            Fortschritt fortschritt =
                await this.dbContext
                   .Fortschritt
                    .FirstOrDefaultAsync(x =>
                        x.UserId == this.currentUserService.GetId()
                        && x.LektionId == lektionId
                        && !x.BereichId.HasValue);

            if (fortschritt != null)
            {
                this.dbContext.Fortschritt.Remove(fortschritt);
            }

            return await this.dbContext.SaveChangesAsync();
        }

        public async Task<int> ResetLektionBereichAsync(int lektionId, int bereichId)
        {
            Fortschritt fortschritt =
                await this.dbContext
                    .Fortschritt
                    .FirstOrDefaultAsync(x =>
                        x.UserId == this.currentUserService.GetId()
                        && x.LektionId == lektionId
                        && x.BereichId.HasValue
                        && x.BereichId.Value == bereichId);

            if (fortschritt != null)
            {
                this.dbContext.Fortschritt.Remove(fortschritt);
            }

            return await this.dbContext.SaveChangesAsync();
        }
    }
}
