using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BusinessLogic;
using Common.ViewModels;
using COMP1640.WebAPI.Services.Token;
using Common.ViewModels.Authenticate;
using Microsoft.Extensions.Logging;

namespace COMP1640.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(UserService userService, ITokenService tokenService, ILogger<AuthController> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LogInModel logInModel)
        {
            if (logInModel is null)
            {
                //_logger.LogWarning("Login request is null");
                return BadRequest("Invalid client request");
            }

            var user = await _userService.AuthenticateUser(logInModel.Email, logInModel.Password);
            if (user is null)
            {
                //_logger.LogWarning("User authentication failed for email: {Email}", logInModel.Email);
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, logInModel.Email),
                new Claim(ClaimTypes.Role, "User")
            };
            var token = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            // Save refresh token to the user (implementation not shown here)
            await _userService.SaveRefreshToken(user.Id, refreshToken);

            //_logger.LogInformation("User logged in successfully: {Email}", logInModel.Email);

            return Ok(new AuthenticatedResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                Email = user.Email,
                Avatar = user.Avatar
            });
        }

        [HttpPost, Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var tokenResponse = await _userService.RefreshToken(new AuthenticatedResponse
            {
                Token = request.Token,
                RefreshToken = request.RefreshToken
            });

            if (tokenResponse == null)
            {
                //_logger.LogWarning("Invalid refresh token");
                return Unauthorized("Invalid refresh token");
            }

            return Ok(tokenResponse);
        }
    }
}
