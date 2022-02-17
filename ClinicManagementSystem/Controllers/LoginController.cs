using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //1 Dependency injection for Iconfig
        private readonly IConfiguration _iconfig;

        private readonly IUsersRepo _iconfig2;

        //2 Constructor Inject
        public LoginController(IConfiguration iconfig, IUsersRepo icon)
        {
            _iconfig = iconfig;
            _iconfig2 = icon;

        }


        //3 HttpPost
        [HttpPost("token")]
        public async Task<IActionResult> Login([FromBody] Users user)
        {


            IActionResult response = Unauthorized();
            Users loginUser = await AuthenticateUser(user);

            if (loginUser != null)
            {
                var tokenString = GenerateJSONWebToken(loginUser);
                response = Ok(new { Token = tokenString,
                                    RoleId=loginUser.RoleId,
                                    UserId=loginUser.UserId,
                                    UserName=loginUser.UserName});
            }

            return response;
        }


        //4 Authenticate User
        private async Task<Users> AuthenticateUser(Users user)
        {
            Users loginUser = null;

            //Validate the User Credentials    
            //Passed HardCoded Val  can get from DB
            if (user.UserName!=null)
            {
                var userLogin= await _iconfig2.GetUserByUserNamePassword(user.UserName,user.Password);
                if(userLogin!=null)
                {
                    loginUser = new Users
                    {
                        UserName = userLogin.UserName,
                        Password = userLogin.Password,
                        FirstName = userLogin.FirstName,
                        UserId = userLogin.UserId,
                        RoleId = (int)userLogin.RoleId
                    };
                }
                else
                {
                    loginUser = new Users
                    {
                        UserName = "0",
                        Password = "0",
                        FirstName = "0",
                        UserId = 0,
                        RoleId = 0
                    };
                }
               

            }
            return loginUser;
        }


        //5 Generate JWT Token
        private object GenerateJSONWebToken(object loginUser)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfig["Jwt:Key"]));
            
            //security credential
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //generate token
            var token = new JwtSecurityToken(
              _iconfig["Jwt:Issuer"],
              _iconfig["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(2),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    
}
