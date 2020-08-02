namespace VokaTester.Features.Vokabeln
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VokaTester.Features.Vokabeln.Dto;

    public interface IVokabelService
    {
        Task<IEnumerable<VokabelDto>> All();

        public Task<IEnumerable<VokabelDto>> ByLektion(int lektionId);

        Task<IEnumerable<VokabelDto>> ByWortnetz(string wortnetz);

        Task<VokabelDto> Single(int id);
    }
}
