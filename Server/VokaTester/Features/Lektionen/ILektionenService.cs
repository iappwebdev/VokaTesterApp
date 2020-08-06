namespace VokaTester.Features.Lektionen
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VokaTester.Features.Lektionen.Dto;

    public interface ILektionenService
    {
        Task<IEnumerable<LektionDto>> AllAsync();
        
        Task<LektionDto> SingleAsync(int id);
    }
}
