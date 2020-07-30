namespace VokaTester.Features.WortArt
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.StringSimilarity;
    using VokaTester.Features.WortArt.Models;

    public class WortArtService : IWortArtService
    {
        private readonly VokaTesterDbContext dbContext;
        private readonly IGeneralizeStringService generalizeStringService;
        private readonly HttpClient httpClient = new HttpClient();

        public WortArtService(
            VokaTesterDbContext dbContext,
            IGeneralizeStringService generalizeStringService)
        {
            this.dbContext = dbContext;
            this.generalizeStringService = generalizeStringService;
        }

        public async Task<IEnumerable<string>> SetWortart()
        {
            List<Vokabel> vokabeln =
                await this.dbContext
                    .Vokabel
                    .Where(x => !x.Deu.Contains(" "))
                    .Take(10)
                    .ToListAsync();

            foreach (Vokabel vokabel in vokabeln)
            {
                string deuSanitized = this.generalizeStringService.SanitizeString(vokabel.Deu);
                string response = await this.httpClient.GetStringAsync("https://www.dwds.de/api/wb/snippet/?q=" + deuSanitized);

                if (response != "[]")
                {
                    List<DwdsResponse> dwdsResponses = JsonConvert.DeserializeObject<List<DwdsResponse>>(response);
                    bool gotResult = dwdsResponses.Where(x => !string.IsNullOrWhiteSpace(x.Wortart)).Any();

                    if (gotResult)
                    {
                        string wortarten = string.Join("|", dwdsResponses.Select(x => x.Wortart));
                        vokabel.Wortart = wortarten;
                    }
                    else
                    {
                        vokabel.Wortart = "NULL";
                    }
                }
                else
                {
                    vokabel.Wortart = "N/A";
                }
            }

            await dbContext.SaveChangesAsync();

            return vokabeln.Select(x => $"{x.Deu}: {x.Wortart}");
        }
    }
}
