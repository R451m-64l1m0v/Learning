using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RegisterToDoc.BD;
using RegisterToDoc.Models;
using RegisterToDoc.Data;
using RegisterToDoc.Areas.Identity.Data;

namespace RegisterToDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private RegisterToDocContext _dbContext;
        private readonly UserManager<RegisterToDocUser> _userManager;
        private readonly SignInManager<RegisterToDocUser> _signInManager;

        public ValuesController(RegisterToDocContext dbContext,
            UserManager<RegisterToDocUser> userManager,
            SignInManager<RegisterToDocUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("getToken")]
        public async Task<ActionResult> GetToken([FromBody] UserLoginModelType loginModel)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == loginModel.Email);
            if (user != null)
            {
                var signInResult = await _signInManager
                    .CheckPasswordSignInAsync(user, loginModel.Password, false);

                if (signInResult.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("MY_BIG_SECRET_KEY_LKSHDJFLSDKJFW@#($)(#)34234");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, loginModel.Email)
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Ok("failed, try again");
                }
            }
            return Ok("failed, try again");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserLoginModelType loginModel)
        {

            RegisterToDocUser registerToDocUser = new RegisterToDocUser()
            {
                Email = loginModel.Email,
                UserName = loginModel.Email,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(registerToDocUser, loginModel.Password);

            if (result.Succeeded)
            {
                return Ok(new { Result = "Register Succes" });
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.Append(error.Description);
                    stringBuilder.Append("\r\n");
                }
                return Ok(new { Result = $"Register Fail:{stringBuilder.ToString()}" });
            }


        }
    }


}
