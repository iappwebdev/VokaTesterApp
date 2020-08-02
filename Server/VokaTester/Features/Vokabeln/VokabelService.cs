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

        public async Task<IEnumerable<VokabelDto>> All()
            => await this.dbContext
                .Vokabel
                .Select(x => this.mapper.Map<VokabelDto>(x))
                .ToListAsync();

        public async Task<IEnumerable<VokabelDto>> ByLektion(int lektionId)
            => await this.dbContext
                .Vokabel
                .Where(x => x.LektionId == lektionId)
                .Select(x => this.mapper.Map<VokabelDto>(x))
                .ToListAsync();

        public async Task<IEnumerable<VokabelDto>> ByWortnetz(string wortnetz)
            => await this.dbContext
                .Vokabel
                .Where(x => x.WortnetzList.Contains(wortnetz))
                .Select(x => this.mapper.Map<VokabelDto>(x))
                .ToListAsync();

        public async Task<VokabelDto> Single(int id)
        {
            Vokabel res =
                await this.dbContext
                   .Vokabel
                   .FirstOrDefaultAsync(x => x.Id == id);

            return this.mapper.Map<VokabelDto>(res);
        }
    }
}
