namespace VokaTester.Features.VokabelSpellCheck
{
    using System.Threading.Tasks;
    using VokaTester.Features.VokabelSpellCheck.Dto;

    public interface IVokabelSpellCheckService
    {
        Task<CheckVokabelResponse> CheckSpellingVokabelAsync(int vokabelId, string frz, bool isPrevVokabel, bool isForBereich = false);
    }
}
