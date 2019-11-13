using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWTAuthentication.DTO;
using JWTAuthentication.Models;
using JWTAuthentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController(IConfiguration configuration)
        {
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            IActionResult response = Conflict();
            var user = UserService.Instance.Register(userDto);

            if (user != null)
            {
                var tokenString = UserService.Instance.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserDto userDto)
        {
            IActionResult response = Unauthorized();
            var user = UserService.Instance.Login(userDto);

            if (user != null)
            {
                var tokenString = UserService.Instance.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [HttpPost]
        public IActionResult Test([FromBody]string jwtToken)
        {
            IActionResult response = Unauthorized();
            
            try
            {
                if (UserService.Instance.ValidateToken(jwtToken))
                {
                    response = Ok();
                }
            }
            catch
            {

            }
            
            return response;
        }
    }
}
