using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace WebApi.Controllers
{
    [Authorize]   
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        BL.UsersManager bl_usersManager = new BL.UsersManager();

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(User user)
        {
            int checkLogin = bl_usersManager.Login(user.UserName, user.UserPwd);

            if (checkLogin == 1)
            {
                return BadRequest(new { message = "Connect databse failed" });
            }
            else if (checkLogin == 2)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("daskjdhsjkdhsajkdhjdhasjkdhasmncxnmcbheaggdhjawdg");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddSeconds(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            Console.WriteLine(DateTime.Now.AddSeconds(1));
            return Ok(new {token = token});
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}