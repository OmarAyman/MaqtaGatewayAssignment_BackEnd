using EmployeeAPI.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IConfiguration configuration;

        public AuthenticationController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {

            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            if (user.UserName == configuration.GetSection("JWT").GetSection("UserName").Value && user.Password == configuration.GetSection("JWT").GetSection("Password").Value)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWT").GetSection("Secret").Value));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(issuer: configuration.GetSection("JWT").GetSection("ValidIssuer").Value, audience: configuration.GetSection("JWT").GetSection("ValidAudience").Value, claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTTokenResponse
                {
                    Token = tokenString
                });
            }
            return Unauthorized();
        }
    }
}
