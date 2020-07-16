using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VokaTester.Models.Vokabel;

namespace VokaTester.Controllers
{
    public class VokabelController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVokabelRequestModel model)
        {

        }
    }
}
