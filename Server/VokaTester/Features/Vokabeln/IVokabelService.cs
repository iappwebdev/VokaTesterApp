namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VokaTester.Features.Vokabeln.Models;

    public interface IVokabelService
    {
        Task<int> Create(string frz, string deu, int lektionId);

        Task<LektionListingServiceModel> Lektion(int lektionId);

        Task<IEnumerable<LektionListingServiceModel>> Lektionen();

        public Task<IEnumerable<VokabelListingServiceModel>> ByLektion(int lektionId);

        Task<IEnumerable<VokabelListingServiceModel>> ByWortnetz(string wortnetz);
        
        public Task<VokabelDetailsServiceModel> Details(int id);
    }
}
