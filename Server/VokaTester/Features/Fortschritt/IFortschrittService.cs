namespace VokaTester.Features.Fortschritt
{
    using System.Threading.Tasks;
    using VokaTester.Features.Fortschritt.Dto;

    public interface IFortschrittService
    {
        Task<FortschrittDto> SingleAsync(int lektionId);
        
        Task<int> ResetAsync(int lektionId);
    }
}
