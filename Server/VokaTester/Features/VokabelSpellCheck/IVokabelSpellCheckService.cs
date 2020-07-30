namespace VokaTester.Features.VokabelSpellCheck
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VokaTester.Data.Models;
    using VokaTester.Features.VokabelSpellCheck.Models;

    public interface IVokabelSpellCheckService
    {
        Task<VokabelSpellCheckResult> CheckSpelling(Vokabel vokabel, string answer);

        Task<VokabelSpellCheckResult> CheckSpelling(int vokabelId, string frz);
    }
}
