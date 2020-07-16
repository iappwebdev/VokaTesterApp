namespace VokaTester.Features.Vokabeln
{
    using System.Threading.Tasks;
    using VokaTester.Data;
    using VokaTester.Data.Models;

    public class VokabelService : IVokabelService
    {
        private readonly VokaTesterDbContext dbContext;

        public VokabelService(VokaTesterDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

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
