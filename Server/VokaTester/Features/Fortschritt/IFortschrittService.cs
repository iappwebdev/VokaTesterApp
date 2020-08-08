namespace VokaTester.Features.Fortschritt
{
    using System.Threading.Tasks;
    using VokaTester.Features.Fortschritt.Dto;

    public interface IFortschrittService
    {
        Task<FortschrittDto> ByLektionAsync(int lektionId);
        
        Task<FortschrittDto> ByLektionBereichAsync(int lektionId, int bereichId);

        Task<int> FinishLektionAsync(int lektionId);

        Task<int> FinishLektionBereichAsync(int lektionId, int bereichId);

        Task<int> ResetLektionAsync(int lektionId);

        Task<int> ResetLektionBereichAsync(int lektionId, int bereichId);
    }
}
