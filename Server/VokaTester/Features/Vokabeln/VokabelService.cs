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

        public async Task<IEnumerable<VokabelDto>> PreviousBySimilarity(int vokabelId, string pattern)
        {
            Vokabel vokabel = this.dbContext.Vokabel.Find(vokabelId);

            return await this.dbContext
                .Vokabel
                .Where(x => x.Id < vokabelId
                            && !x.FrzSan.Contains(vokabel.FrzSan)
                            && x.FrzSan.Contains(pattern))
                .OrderByDescending(x => x.Id)
                .Take(10)
                .Select(x => this.mapper.Map<VokabelDto>(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<VokabelDto>> ByWortnetzAsync(string wortnetz)
            => await this.dbContext
                .Vokabel
                .Where(x => x.WortnetzList.Contains(wortnetz))
                .Select(x => this.mapper.Map<VokabelDto>(x))
                .ToListAsync();

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
