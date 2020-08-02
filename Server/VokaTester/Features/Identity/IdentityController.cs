namespace VokaTester.Features.Identity
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using VokaTester.Data.Models;
    using VokaTester.Features;
    using VokaTester.Features.Identity.Dto;

    [Route("api/identity")]
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;
        private readonly IIdentityService identityService;

        public IdentityController(
            UserManager<User> userManager,
            IIdentityService identityService,
            IOptions<AppSettings> appSettingsOptions)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettingsOptions.Value;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterUserRequestDto model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

            return result.Succeeded ? Ok() : (ActionResult)BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginDto model)
        {
            User user = await this.userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            bool passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            string token = this.identityService.GenerateJwtToken(user.Id, user.UserName, this.appSettings.Secret);

            return new LoginResponseDto
            {
                Token = token
            };
        }
    }
}
