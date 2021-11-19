using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nascimento.Software.Campeonatos.Api.Configuration;
using Nascimento.Software.Campeonatos.Api.models.DTO.Identity.Request;
using Nascimento.Software.Campeonatos.Api.models.DTO.Identity.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Nascimento.Software.Campeonatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagerController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthManagerController(
            UserManager<IdentityUser> userManager,
            IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<ActionResult> Registration([FromBody] UserRegistrationDTO userRegister)
        {
            if (ModelState.IsValid)
            {
                var userAlreadyExists = await _userManager.FindByEmailAsync(userRegister.Email);
                if (userAlreadyExists != null)
                {
                    return BadRequest("Email already in use");
                }

                var user = new IdentityUser()
                {
                    Email = userRegister.Email,
                    UserName = userRegister.Name,
                };
                var isCreated = await _userManager.CreateAsync(user, userRegister.Password);
                if (isCreated.Succeeded)
                {
                    var token = GenerateJwtToken(user);

                    return Ok(new RegistrationResponse()
                    {
                        Token = token,
                        Success = true,
                    });
                }
                else
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var userExists = await _userManager.FindByEmailAsync(user.Email);
                if (userExists == null)
                {
                    return BadRequest("A tentativa de login falhou.");
                }

                var valid = await _userManager.CheckPasswordAsync(userExists, user.Password);
                if (!valid)
                {
                    return BadRequest("Tentativa de login falhou");
                }

                var jwtToken = GenerateJwtToken(userExists);
                return Ok(new RegistrationResponse()
                {
                    Success = true,
                    Token = jwtToken,
                });
            }
            return BadRequest();
        }
        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }

    }
}
