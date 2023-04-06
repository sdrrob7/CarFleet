using CarFleet.Models;
using BusinessLayer.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SharedModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace CarFleet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;
        public AccountController(IUserService userService, IOptions<JwtSettings> options)
        {
            _userService = userService;
            _jwtSettings = options.Value;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Post(UserModelBind model)
        {
            if (ModelState.IsValid)
            {
                await _userService.InsertAsync(model);
                return Ok("User added Successfully");
            }
            else
                return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("GetToken")]
        public async Task<IActionResult> GenerateToken(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if(await _userService.checkUserNamePassword(model.UserName, model.Password))
                {
                    var tokenhandler = new JwtSecurityTokenHandler();
                    var tokenkey = Encoding.UTF8.GetBytes(_jwtSettings.securitykey);
                    var tokenDesc = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(
                            new Claim[] { new Claim(ClaimTypes.Name, model.UserName) }
                            ),
                        Expires = DateTime.Now.AddMinutes(20),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                    };
                    var token = tokenhandler.CreateToken(tokenDesc);
                    return Ok(tokenhandler.WriteToken(token));
                }
                return Unauthorized();
            }
            else return BadRequest(ModelState);
        }
    }
}
