using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TestServer.BL.Models.Auth;
using TestServer.DTO.General;

namespace TestServer.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class LoginController : Controller
    {
        private readonly IOptions<AuthOptions> authOptions;
        public LoginController(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            if (user != null)
            {
                var token = GenerateJWT(user);
                return Ok(new
                {
                    access_token = token
                });
            }
            return null;
        }
        private string GenerateJWT(UserDTO user)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credetnials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            };
            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credetnials);
            return new JwtSecurityTokenHandler().WriteToken(token);

          
        }
    }
}
