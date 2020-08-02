namespace VokaTester.Features.VokabelSpellCheck
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VokaTester.Data.Models;
    using VokaTester.Features.VokabelSpellCheck.Dto;

    public interface IVokabelSpellCheckService
    {
        Task<CheckVokabelResponse> CheckSpelling(Vokabel vokabel, string answer);

        Task<CheckVokabelResponse> CheckSpelling(int vokabelId, string frz);
    }
}
