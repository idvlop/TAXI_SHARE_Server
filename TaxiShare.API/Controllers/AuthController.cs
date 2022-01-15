using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TaxiShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //[HttpPost("/login")]
        //public async Task<IActionResult> Login(string username, string password)
        //{
        //    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
        //    var jwt = new JwtSecurityToken(
        //            issuer: AuthOptions.ISSUER,
        //            audience: AuthOptions.AUDIENCE,
        //            claims: claims,
        //            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
        //            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        //    return Ok(new { Token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(jwt) });
        //}
    }
}
