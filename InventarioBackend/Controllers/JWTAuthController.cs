//using Database.FEInsepet.DataBase;
//using Database.FEInsepet.DataBase.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using static Models.Authenticator.ValidateModel;

//namespace WsLectura.Controllers
//{
//    public class JWTAuthenticationController : Controller
//    {
//        private readonly IConfiguration _configuration;

//        public JWTAuthenticationController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        [HttpPost("login")]
//        public IActionResult Login([FromBody] ValidateStation userLogin)
//        {
//            Estacion estacion = feinsepetContext.Estacion.Where(est => est.Nitestacion == userLogin.Nit).FirstOrDefault();
//            //Validacion de usuario por una consulta
//            if (userLogin.Nit == estacion.Nitestacion/* && userLogin.Password == "123"*/)
//            {
//                var token = GenerateJwtToken(userLogin.Nit);
//                return Ok(new { token });
//            }
//            return Unauthorized("Credenciales inválidas");
//        }

//        private string GenerateJwtToken(string username)
//        {
//            var jwtSettings = _configuration.GetSection("JwtSettings");
//            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new Claim[]
//                {
//                new Claim(ClaimTypes.Name, username),
//                new Claim(ClaimTypes.Role, "Estacion")
//                }),
//                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings["Duration"])),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };

//            var tokenHandler = new JwtSecurityTokenHandler();
//            var token = tokenHandler.CreateToken(tokenDescriptor);

//            return tokenHandler.WriteToken(token);
//        }
//    }
//}
