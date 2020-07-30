namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.Vokabeln.Models;

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

        public async Task<LektionListingServiceModel> Lektion(int lektionId)
        {
            Lektion res =
                await this.dbContext
                   .Lektion
                   .FirstOrDefaultAsync(x => x.Id == lektionId);

            return this.mapper.Map<LektionListingServiceModel>(res);
        }

        public async Task<IEnumerable<LektionListingServiceModel>> Lektionen()
            => await this.dbContext
                .Lektion
                .Select(x => this.mapper.Map<LektionListingServiceModel>(x))
                .ToListAsync();

        public async Task<IEnumerable<VokabelListingServiceModel>> ByLektion(int lektionId)
            => await this.dbContext
                .Vokabel
                .Where(x => x.LektionId == lektionId)
                .Select(x => this.mapper.Map<VokabelListingServiceModel>(x))
                .ToListAsync();

        public async Task<IEnumerable<VokabelListingServiceModel>> ByWortnetz(string wortnetz)
            => await this.dbContext
                .Vokabel
                .Where(x => x.WortnetzList.Contains(wortnetz))
                .Select(x => this.mapper.Map<VokabelListingServiceModel>(x))
                .ToListAsync();

        public async Task<int> Create(string frz, string deu, int lektionId)
        {
            var vokabel = new Vokabel()
            {
                Frz = frz,
                Deu = deu,
                Phonetik = "N/A",
                LektionId = lektionId
            };

            this.dbContext.Add(vokabel);

            await this.dbContext.SaveChangesAsync();

            return vokabel.Id;
        }

        public async Task<VokabelDetailsServiceModel> Details(int id)
            => await this.dbContext
                .Vokabel
                .Where(x => x.Id == id)
                .Select(x => new VokabelDetailsServiceModel
                {
                    Id = x.Id,
                    LektionName = x.Lektion.Name,
                    Frz = x.Frz,
                    Deu = x.Deu,
                    Phonetik = x.Phonetik
                })
                .FirstOrDefaultAsync();
    }
}
