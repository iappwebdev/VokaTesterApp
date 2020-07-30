namespace VokaTester.Features.VokabelSpellCheck
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.VokabelSpellCheck.Models;
    using VokaTester.Infrastructure.Services;

    //[Authorize]
    public class VokabelSpellCheckController : ApiController
    {
        private readonly IVokabelSpellCheckService vokabelSpellCheckService;
        private readonly ICurrentUserService currentUser;

        public VokabelSpellCheckController(
            IVokabelSpellCheckService vokabelSpellCheckService,
            ICurrentUserService currentUser)
        {
            this.vokabelSpellCheckService = vokabelSpellCheckService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<VokabelSpellCheckResult> CheckSpelling(int vokabelId, string frz)
            => await this.vokabelSpellCheckService.CheckSpelling(vokabelId, frz);
    }
}
