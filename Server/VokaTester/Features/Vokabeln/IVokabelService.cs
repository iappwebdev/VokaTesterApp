namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VokaTester.Features.Vokabeln.Dto;

    public interface IVokabelService
    {
        Task<IEnumerable<VokabelDto>> AllAsync();

        Task<IEnumerable<VokabelDto>> ByLektionAsync(int lektionId);

        Task<IEnumerable<VokabelDto>> ByLektionBereichAsync(int lektionId, int bereichId);

        Task<IEnumerable<VokabelDto>> PreviousBySimilarity(int vokabelId, char pattern, char? prev, char? next);

        Task<VokabelDto> SingleAsync(int id);
    }
}
