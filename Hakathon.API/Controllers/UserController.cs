using Hakathon.API.infrastructure.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Hakathon.Application.Users;
using Hakathon.Application.Users.Requests;
namespace Hakathon.API.Controllers
{
    [Route("api/credentials")]
    [AllowAnonymous]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<JWTConfiguration> _options;

        public UserController(IUserService userService, IOptions<JWTConfiguration> options)
        {
            _userService = userService;
            _options = options;
        }
        [Route("register")]
        [HttpPost]
        public async Task<string> Register(UserCreateModel user, CancellationToken cancellation = default)
        {
            var result = await _userService.CreateAsync(user, cancellation);
            return result;
        }
        [Route("login")]
        [HttpPost]
        //UserLogInRequest
        public async Task<string> Login(UserLoginModel user, CancellationToken cancellation = default)
        {
            var result = await _userService.AuthenticationAsync(user.Username, user.Password, cancellation);
            return JWTHelper.GenerateSecurityToken(result, _options);
        }
    }
}