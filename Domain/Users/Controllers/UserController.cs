using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using programming_work_backend.Data;
using programming_work_backend.Domain.Users.Models;

namespace programming_work_backend.Domain.Users.Controllers;

[ApiController]
[Route("api/v1/user")]
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
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            // Validate incoming data
            if (string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest(new
                {
                    success = false,
                    message = "El nombre de usuario y la contraseña son obligatorios.",
                    result = ""
                });
            }

            // Verify user credentials
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Name == loginRequest.Username && x.Password == loginRequest.Password);

            if (user == null)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                });
            }

            // Generate JWT token
            var jwtConfig = _configuration.GetSection("Jwt").Get<JwtConfig>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwtConfig.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Name),
                new Claim("role", user.Rol)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwtConfig.Issuer,
                jwtConfig.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signIn
            );

            // Return the JWT along with user data
            return Ok(new
            {
                success = true,
                message = "Inicio de sesión exitoso",
                result = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    user = new
                    {
                        user.Id,
                        user.Name,
                        user.Rol,
                    }
                }
            });
        }
        catch (JsonReaderException ex)
        {
            return BadRequest(new
            {
                success = false,
                message = "Formato JSON inválido",
                details = ex.Message
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                message = "Ocurrió un error al procesar la solicitud.",
                details = ex.Message
            });
        }
    }
}

// DTO for login request
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
