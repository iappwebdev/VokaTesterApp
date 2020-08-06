namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VokaTester.Features.Vokabeln.Dto;

    public interface IVokabelService
    {
        Task<IEnumerable<VokabelDto>> AllAsync();

        Task<IEnumerable<VokabelDto>> ByLektionAsync(int lektionId);

        Task<IEnumerable<VokabelDto>> ByWortnetzAsync(string wortnetz);
        
        Task<IEnumerable<VokabelDto>> PreviousBySimilarity(int vokabelId, string pattern);

        Task<VokabelDto> SingleAsync(int id);
    }
}
