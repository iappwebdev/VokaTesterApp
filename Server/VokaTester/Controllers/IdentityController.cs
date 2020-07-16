namespace VokaTester.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using VokaTester.Data.Models;
    using VokaTester.Models.Identity;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;

        public IdentityController(
            UserManager<User> userManager,
            IOptions<AppSettings> appSettingsOptions)
        {
            this.userManager = userManager;
            this.appSettings = appSettingsOptions.Value;
        }

        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
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

            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(this.appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                { 
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string encryptedToken = tokenHandler.WriteToken(token);

            return new LoginResponseModel
            {
                Token = encryptedToken
            };
        }

        //public async Task<IActionResult> Login2(LoginRequestModel model)
        //{
        //    User user = await this.userManager.FindByNameAsync(model.UserName);
        //    if (user == null)
        //    {
        //        return Unauthorized();
        //    }

        //    bool passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
        //    if (!passwordValid)
        //    {
        //        return Unauthorized();
        //    }

        //    var token = this.identityService.GenerateJwtToken(
        //        user.Id,
        //        user.UserName,
        //        this.appSettings.Value.Secret);

        //    return new LoginResponseModel
        //    {
        //        Token = token
        //    };
        //}

    }
}
