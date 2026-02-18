using LittleLibraryAPI.Entities;
using LittleLibraryAPI.Models;
using LittleLibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LittleLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
                return BadRequest("Username already exists.");

            return Ok(user);
        }
    

    [HttpPost("login")]
        public async Task<ActionResult<LoginDto>> Login(UserDto request)
        {
            var token = await authService.LoginAsync(request);

            if (token is null)
            {
                return BadRequest(new LoginDto { Message = "Invalid username or password." });
            }

            return Ok(new LoginDto { Token = token });
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are authenticated!");
        }
    }
}