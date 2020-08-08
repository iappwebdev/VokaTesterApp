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
                this.SetAdditionalInfos(res, lektion);
            }

            return results;
        }


        public async Task<LektionDto> SingleAsync(int id)
        {
            Lektion lektion =
                await this.dbContext
                   .Lektion
                   .FirstOrDefaultAsync(x => x.Id == id);

            if (lektion == null)
            {
                return null;
            }

            LektionDto res = this.mapper.Map<LektionDto>(lektion);
            this.SetAdditionalInfos(res, lektion);

            return res;
        }


        public async Task<LektionDto> SingleByKeyAsync(string key)
        {
            Lektion lektion =
                await this.dbContext
                   .Lektion
                   .FirstOrDefaultAsync(x => x.Key == key);

            if (lektion == null)
            {
                return null;
            }

            LektionDto res = this.mapper.Map<LektionDto>(lektion); 
            this.SetAdditionalInfos(res, lektion);

            return res;
        }

        private void SetAdditionalInfos(LektionDto res, Lektion lektion)
        {
            this.SetBereichInfo(lektion, res);
            this.SetFortschrittInfoLektion(lektion, res);
            this.SetFortschrittInfoBereich(lektion, res);
        }

        private void SetBereichInfo(Lektion lektion, LektionDto res)
        {
            res.Bereiche.ForEach(bereich =>
            {
                bereich.LektionName = lektion.Name;
                bereich.Total = lektion.Vokabeln.Where(x => x.BereichId == bereich.Id).Count();
            });
        }

        private void SetFortschrittInfoLektion(Lektion lektion, LektionDto res)
        {
            Fortschritt fortschritt =
                lektion.Fortschritte
                .FirstOrDefault(x =>
                    x.UserId == this.currentUserService.GetId()
                    && !x.BereichId.HasValue);

            if (fortschritt != null)
            {
                res.IsStarted = true;
                res.IsCompleted = fortschritt.Durchlauf > 1;

                if (fortschritt.LetzteVokabelCorrect != null
                    && fortschritt.LetzteVokabelWrongId != null)
                {
                    res.Position =
                        fortschritt.LetzteVokabelCorrect.Id < fortschritt.LetzteVokabelWrong.Id
                        ? fortschritt.LetzteVokabelCorrect.PositionLektion
                        : fortschritt.LetzteVokabelWrong.PositionLektion;
                }
                else if (fortschritt.LetzteVokabelCorrectId.HasValue)
                {
                    res.Position = fortschritt.LetzteVokabelCorrect.PositionLektion;
                }
                else if (fortschritt.LetzteVokabelWrongId.HasValue)
                {
                    res.Position = fortschritt.LetzteVokabelWrong.PositionLektion;
                }
            }
        }

        private void SetFortschrittInfoBereich(Lektion lektion, LektionDto res)
        {
            List<Fortschritt> fortschritte =
                lektion.Fortschritte
                .Where(x =>
                    x.UserId == this.currentUserService.GetId()
                    && x.BereichId.HasValue)
                .ToList();

            if (fortschritte.Any())
            {
                IEnumerable<(Fortschritt fortschritt, BereichDto resBereich)> fortSchrittWithBereich =
                    from Fortschritt fortschritt in fortschritte
                    let resBereich = res.Bereiche.FirstOrDefault(x => x.Id == fortschritt.BereichId)
                    where resBereich != null
                    select (fortschritt, resBereich);

                foreach ((Fortschritt fortschritt, BereichDto resBereich) in fortSchrittWithBereich)
                {
                    resBereich.IsStarted = true;
                    resBereich.IsCompleted = fortschritt.Durchlauf > 1;
                    
                    if (fortschritt.LetzteVokabelCorrect != null
                        && fortschritt.LetzteVokabelWrongId != null)
                    {
                        resBereich.Position =
                            fortschritt.LetzteVokabelCorrect.Id < fortschritt.LetzteVokabelWrong.Id
                            ? fortschritt.LetzteVokabelCorrect.PositionLektion
                            : fortschritt.LetzteVokabelWrong.PositionLektion;
                    }
                    else if (fortschritt.LetzteVokabelCorrectId.HasValue)
                    {
                        resBereich.Position = fortschritt.LetzteVokabelCorrect.PositionLektion;
                    }
                    else if (fortschritt.LetzteVokabelWrongId.HasValue)
                    {
                        resBereich.Position = fortschritt.LetzteVokabelWrong.PositionLektion;
                    }
                }
            }
        }
    }
}
