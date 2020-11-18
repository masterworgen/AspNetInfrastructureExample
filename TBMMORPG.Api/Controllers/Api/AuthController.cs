using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TBMMORPG.Api.Model;
using TBMMORPG.Auth.Services.Interface;
using TBMMORPG.Infrastructure.Domain;
using TBMMORPG.Infrastructure.Services.Interface;

namespace TBMMORPG.Api.Controllers.Api
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IJWTService _jwtService;

        public AuthController(IUserService userService, IJWTService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] AuthModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = _jwtService.GenerateJSONWebToken(user.UserName);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private UserDomain AuthenticateUser(AuthModel login)
        {
            UserDomain user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            user = _userService.Auth(login.Login, login.Password);
            return user;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Reg")]
        public IActionResult Registration(AuthModel authModel)
        {
            _userService.Registration(authModel.Login, authModel.Password);

            return Ok();
        }
    }
}
