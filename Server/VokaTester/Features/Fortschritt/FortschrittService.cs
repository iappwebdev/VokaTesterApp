namespace VokaTester.Features.Fortschritt
{
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

        public async Task<int> ResetAsync(int lektionId)
        {
            Fortschritt fortschritt =
                await this.dbContext
                   .Fortschritt
                   .FirstOrDefaultAsync(x => x.UserId == this.currentUserService.GetId() && x.LektionId == lektionId);

            this.dbContext.Fortschritt.Remove(fortschritt);

            return await this.dbContext.SaveChangesAsync();
        }

        public async Task<FortschrittDto> SingleAsync(int lektionId)
        {
            Fortschritt fortschritt =
                await this.dbContext
                   .Fortschritt
                   .FirstOrDefaultAsync(x => x.UserId == this.currentUserService.GetId() && x.LektionId == lektionId);

            if (fortschritt == null)
            {
                Lektion lektion = await this.dbContext.Lektion.FirstAsync(x => x.Id == lektionId);

                return new FortschrittDto
                {
                    UserId = currentUserService.GetId(),
                    UserUserName = currentUserService.GetUserName(),
                    LektionId = lektion.Id,
                    LektionName = lektion.Name,
                    LetzteVokabelCorrectId = lektion.FirstVokabel.Id,
                    LetzteVokabelCorrectFrz = lektion.FirstVokabel.Frz,
                    IsBeginning = true,
                };
            }

            return this.mapper.Map<FortschrittDto>(fortschritt);
        }
    }
}
