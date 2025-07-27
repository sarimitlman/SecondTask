using BL.Api;
using Dal.DTO;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IBLUser _userService;
        private readonly TokenService _tokenService;

        public AuthController(IBLUser userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);
            if (user == null || user.PasswordHash != request.Password)
                return Unauthorized("Invalid credentials");

            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }

        // דוגמת פונקציה לאימות סיסמה (Hash + Salt)
        private bool VerifyPassword(string password, string? storedHash, string? storedSalt)
        {
            if (storedHash == null || storedSalt == null) return false;
            using var hmac = new System.Security.Cryptography.HMACSHA256(Convert.FromBase64String(storedSalt));
            var computedHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            return computedHash == storedHash;
        }
    }


}