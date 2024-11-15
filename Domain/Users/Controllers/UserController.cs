using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using programming_work_backend.Data;
using programming_work_backend.Domain.Users.Models;

namespace programming_work_backend.Domain.Jwt;

    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IConfiguration _configuration;

        public UserController(DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> IniciarSesion([FromBody] object optData)
    {
        try
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
            string user = data.usuario.ToString();
            string password = data.password.ToString();

            User usuario = await _context.Users.FirstOrDefaultAsync(x => x.user == user && x.password == password);

            if (usuario == null)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                });
            }

            // Generar token JWT
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64),
                new Claim("id", usuario.id),
                new Claim("usuario", usuario.user)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(4),
                signingCredentials: signIn
            );

            return Ok(new
            {
                success = true,
                message = "Inicio de sesión exitoso",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
        catch (JsonReaderException ex)
        {
            return BadRequest(new { error = "Formato JSON inválido", details = ex.Message });
        }
    }

}

