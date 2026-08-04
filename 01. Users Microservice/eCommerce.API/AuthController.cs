using eCommerce.Core.DTO;
using eCommerce.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("RegisterRequest cannot be null.");
            }

            AuthenticationResponse? authenticationResponse =
                await _usersService.Register(registerRequest);

            if (authenticationResponse == null || !authenticationResponse.Success)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("LoginRequest cannot be null.");
            }

            AuthenticationResponse? authenticationResponse =
                await _usersService.Login(loginRequest);

            if (authenticationResponse == null || !authenticationResponse.Success)
            {
                return Unauthorized(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }
    }
}