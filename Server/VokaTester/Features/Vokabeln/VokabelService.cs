namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.Vokabeln.Dto;

    public class VokabelService : IVokabelService
    {
        private readonly VokaTesterDbContext dbContext;
        private readonly IMapper mapper;

        public VokabelService(
            VokaTesterDbContext dbContext,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<VokabelDto>> AllAsync()
            => await this.dbContext
                .Vokabel
                .Select(x => this.mapper.Map<VokabelDto>(x))
                .ToListAsync();

        public async Task<IEnumerable<VokabelDto>> ByLektionAsync(int lektionId)
            => await this.dbContext
                .Vokabel
                .Where(x => x.LektionId == lektionId)
                .Select(x => this.mapper.Map<VokabelDto>(x))
                .ToListAsync();

        public async Task<IEnumerable<VokabelDto>> ByLektionBereichAsync(int lektionId, int bereichId)
            => await this.dbContext
                .Vokabel
                .Where(x => x.LektionId == lektionId
                            && x.BereichId == bereichId)
                .Select(x => this.mapper.Map<VokabelDto>(x))
                .ToListAsync();

        public async Task<IEnumerable<VokabelDto>> PreviousBySimilarity(int vokabelId, char pattern, char? prev, char? next)
        {
            Vokabel vokabel = this.dbContext.Vokabel.Find(vokabelId);

            List<Vokabel> seenVokabeln = await this.dbContext
                .Vokabel
                .Where(x => x.Id < vokabelId
                            && !x.FrzSan.Contains(vokabel.FrzSan)
                            && !vokabel.FrzSan.Contains(x.FrzSan))
                .ToListAsync();

            var result = new List<Vokabel>();
            int take = 5;

            if (prev.HasValue)
            {
                string prevPattern = string.Concat(prev.Value, pattern);
                var resultPrev =
                    seenVokabeln
                    .Where(x => x.FrzSan.Contains(prevPattern))
                    .OrderByDescending(x => x.Id)
                    .ToList();

                result.AddRange(resultPrev.Take(take));
                seenVokabeln = seenVokabeln.Except(resultPrev).ToList();
            }
            else
            {
                var resultPrev =
                        seenVokabeln
                        .Where(x => x.FrzSan.StartsWith(pattern))
                        .OrderByDescending(x => x.Id)
                        .ToList();

                result.AddRange(resultPrev.Take(take));
                seenVokabeln = seenVokabeln.Except(resultPrev).ToList();
            }

            if (!result.Any())
            {
                if (next.HasValue)
                {
                    string nextPattern = string.Concat(pattern, next.Value);
                    var resultNext =
                        seenVokabeln
                        .Where(x => x.FrzSan.Contains(nextPattern))
                        .OrderByDescending(x => x.Id)
                        .ToList();

                    result.AddRange(resultNext.Take(take));
                    seenVokabeln = seenVokabeln.Except(resultNext).ToList();
                }
                else
                {
                    var resultNext =
                            seenVokabeln
                            .Where(x => x.FrzSan.EndsWith(pattern))
                            .OrderByDescending(x => x.Id)
                            .ToList();

                    result.AddRange(resultNext.Take(take));
                    seenVokabeln = seenVokabeln.Except(resultNext).ToList();
                }
            }

            if (!result.Any())
            {
                var resultPattern =
                    seenVokabeln
                        .Where(x => x.FrzSan.Contains(pattern))
                        .OrderByDescending(x => x.Id)
                        .ToList();

                result.AddRange(resultPattern.Take(take));
            }

            return result
                .Take(take)
                .Select(x => this.mapper.Map<VokabelDto>(x))
                .ToList();
        }

        public async Task<VokabelDto> SingleAsync(int id)
        {
            Vokabel res =
                await this.dbContext
                   .Vokabel
                   .FirstOrDefaultAsync(x => x.Id == id);

            return this.mapper.Map<VokabelDto>(res);
        }
    }
}
