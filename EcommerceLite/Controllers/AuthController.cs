using Microsoft.AspNetCore.Mvc;
using EcommerceLite.Services.Interfaces;

namespace EcommerceLite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(ICustomAuthorizationService authService) : ControllerBase
    {
        private readonly ICustomAuthorizationService _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = await _authService.Register(request.Username, request.Email, request.Password);
            if (user == null)
                return BadRequest("Username or Email already exists or input invalid.");

            return Ok(new { user.Id, user.Username, user.Email });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.Login(request.Identifier, request.Password);
            if (token == null)
                return Unauthorized("Invalid credentials.");

            return Ok(new { Token = token });
        }
    }

    public record RegisterRequest(string Username, string Email, string Password);
    public record LoginRequest(string Identifier, string Password);
}