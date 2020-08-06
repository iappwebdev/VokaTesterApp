
//namespace VokaTester.Features.WortArt
//{
//    using System.Collections.Generic;
//    using System.Threading.Tasks;
//    using Microsoft.AspNetCore.Authorization;
//    using Microsoft.AspNetCore.Mvc;
//    using VokaTester.Features.Identity;
//    using VokaTester.Infrastructure.Services;

//    [Authorize]
//    [Route("api/wortart")]
//    public class WortArtController : ApiController
//    {
//        private readonly IWortArtService wortArtService;

//        public WortArtController(
//            IWortArtService wortVerzeichnisService)
//        {
//            this.wortArtService = wortVerzeichnisService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<string>>> SetWortart()
//        {
//            IEnumerable<string> result = await this.wortArtService.SetWortart();

//            return Ok(result);
//        }

//    }
//}
