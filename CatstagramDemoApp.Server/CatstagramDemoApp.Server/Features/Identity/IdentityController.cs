using CatstagramDemoApp.Server.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CatstagramDemoApp.Server.Features.Identity
{

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;
        private readonly AppSettings appSettings;

        public IdentityController(
            UserManager<User> userManager,
            IIdentityService identityService,
            IOptions<AppSettings> appSettings
        )
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [Route(nameof(Login))]
        public async Task<ActionResult<object>> Login(LoginRequestModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return Unauthorized("no such user");
            }

            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);

            if (passwordValid == false)
            {
                return Unauthorized("incorrect password");
            }

            var token = this.identityService.GenerateJwtToken(
                user.Id,
                user.UserName,
                this.appSettings.Secret
            );

            return new LoginResponseModel() { Token = token};
        }
    }
}
