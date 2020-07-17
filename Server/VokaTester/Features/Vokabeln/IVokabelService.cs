namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VokaTester.Features.Vokabeln.Models;

    public interface IVokabelService
    {
        Task<int> Create(string frz, string deu, int lektionId);

        public Task<IEnumerable<VokabelListingServiceModel>> ByLektion(int lektionId);

        public Task<VokabelDetailsServiceModel> Details(int id);
    }
}
