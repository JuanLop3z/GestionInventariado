using InventarioBackend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventarioBackend.Controllers
{
    [EnableCors("AllowAngular")]
    [ApiController]
    [Route("api/[controller]")]
    public class JWTAuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;

        public JWTAuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] ValidateUser userLogin)
        {
            var defaultUser = new
            {
                user = "admin",
                Password = "admin123"
            };

            // Validación de credenciales contra el usuario por defecto
            if (userLogin.User == defaultUser.user && userLogin.Password == defaultUser.Password)
            {
                var token = GenerateJwtToken(userLogin.User);
                return Ok(new { token });
            }

            return Unauthorized("Credenciales inválidas");
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _configuration.GetSection("JWTSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings["Duration"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
