
namespace VokaTester.Features.WortArt
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using VokaTester.Features.Identity;
    using VokaTester.Infrastructure.Services;

    [Authorize]
    public class WortArtController : ApiController
    {
        private readonly IWortArtService wortArtService;
        private readonly ICurrentUserService currentUser;

        public WortArtController(
            IWortArtService wortVerzeichnisService,
            ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
            this.wortArtService = wortVerzeichnisService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> SetWortart()
        {
            if (!this.User.IsInRole(IdentityRoles.Administrator))
            {
                return Unauthorized();
            }

            IEnumerable<string> result = await this.wortArtService.SetWortart();

            return Ok(result);
        }

    }
}
