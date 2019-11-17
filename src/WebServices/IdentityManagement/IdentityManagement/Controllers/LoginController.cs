using IdentityManagement.Services;
using IdentityManagement.Shared;
using IdentityManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("/Register")]
        public IActionResult Register([FromBody]RegisterViewModel registerViewModel)
        {
            IActionResult response = Conflict();
            var user = UserService.Instance.Register(registerViewModel);

            if (user != null)
            {
                var tokenString = JwtHelper.GenerateJSONWebToken(registerViewModel.Username);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [AllowAnonymous]
        [HttpPost("/Login")]
        public IActionResult Login([FromBody]LoginViewModel loginViewModel)
        {
            IActionResult response = Unauthorized();
            var user = UserService.Instance.Login(loginViewModel);

            if (user != null)
            {
                var tokenString = JwtHelper.GenerateJSONWebToken(loginViewModel.Username);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get([FromBody]string securityToken)
        {
            IActionResult response = Unauthorized();
            if (JwtHelper.ValidateToken(securityToken))
            {
                response = Ok(new { token = securityToken });
            }
            return response;
        }
    }
}
