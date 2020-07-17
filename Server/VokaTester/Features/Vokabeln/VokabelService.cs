namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.Vokabeln.Models;

    public class VokabelService : IVokabelService
    {
        private readonly VokaTesterDbContext dbContext;

        public VokabelService(VokaTesterDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<VokabelListResponseModel>> ByLektion(int lektionId)
            => await this.dbContext
                .Vokabel
                .Where(x => x.LektionId == lektionId)
                .Select(x => new VokabelListResponseModel
                {
                    Id = x.Id,
                    Frz = x.Frz,
                    Deu = x.Deu,
                    Phonetik = x.Phonetik,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync();

        public async Task<int> Create(string frz, string deu, int lektionId)
        {
            var vokabel = new Vokabel()
            {
                Frz = frz,
                Deu = deu,
                Phonetik = "N/A",
                ImageUrl = "N/A",
                LektionId = lektionId
            };

            this.dbContext.Add(vokabel);

            await this.dbContext.SaveChangesAsync();

            return vokabel.Id;
        }
    }
}
