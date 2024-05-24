using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public ActionResult Login(String UserName,String Password)
        {
           if(UserName=="Admin" && Password=="1234")
            {
                //Claims
                List<Claim> UserData = new List<Claim>();
                {
                    UserData.Add(new Claim("UserName", "Admin"));

                    UserData.Add(new Claim(ClaimTypes.MobilePhone, "01286877514"));
                };
                //Signing Credentials
                string Key = "Welcome To MySecret To My Secrit key By Shadiiii 1711";
                var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));

                var SigningCer = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

               // Generate Token
                var token = new JwtSecurityToken(
                    claims:UserData,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: SigningCer
                    );
                // token obj => string encoded 
                var tokenhandler = new JwtSecurityTokenHandler();
               var finalToken=  tokenhandler.WriteToken(token);
                return Ok(finalToken);
            }
            else
            {
                return BadRequest("Login Failed");
            }

        }
        [HttpPost]
        [Authorize]
        public ActionResult Add()
        {
            return Ok();
        }
    }
}
//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTmFtZSI6IkFkbWluIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbW9iaWxlcGhvbmUiOiIwMTI4Njg3NzUxNCIsImV4cCI6MTcxMzYxODIyNH0.AsPsJ389jjRNTfEE7-Yzy2fSt4Hbbd00Pdb_hhRBLPA
