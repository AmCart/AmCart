using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using IdentityManagement.DTO;
using IdentityManagement.Services;
using IdentityManagement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace IdentityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            IActionResult response = Conflict();
            var user = UserService.Instance.Register(userDto);

            if (user != null)
            {
                var tokenString = JwtHelper.GenerateJSONWebToken(user.Email);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [AllowAnonymous]
        //url => /api/login/username/password
        [HttpGet("{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            IActionResult response = Unauthorized();
            var user = UserService.Instance.Login(username, password);

            if (user != null)
            {
                var tokenString = JwtHelper.GenerateJSONWebToken(username);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
    }
}
