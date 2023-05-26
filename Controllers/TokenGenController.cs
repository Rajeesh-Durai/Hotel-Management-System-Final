using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenGenController : ControllerBase
    {
        public IConfiguration _config;
        private readonly RegContext _hotelcontext;

        public TokenGenController(IConfiguration config, RegContext hotelcontext)
        {
            _config = config;
            _hotelcontext = hotelcontext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Register _loginInfo)
        {
            if (_loginInfo != null && _loginInfo.EmailId != null && _loginInfo.Password != null && _loginInfo.Roles != null)
            {
                var user = await GetLogin(_loginInfo.EmailId, _loginInfo.Password, _loginInfo.Roles);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("RegId", user.RegId.ToString()),
                         new Claim("Email", user.EmailId),
                        new Claim("Password",user.Password),
                        new Claim("Role",user.Roles)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Register> GetLogin(string email, string password, string role)
        {
            return await _hotelcontext.Registers.FirstOrDefaultAsync(info => info.EmailId == email && info.Password == password && info.Roles == role);
        }
    }
}
