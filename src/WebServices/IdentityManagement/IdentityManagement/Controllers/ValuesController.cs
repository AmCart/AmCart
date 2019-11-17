using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityManagement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet("{securityToken}")]
        public IActionResult Get(string securityToken)
        {
            IActionResult response = Unauthorized();
            if(JwtHelper.ValidateToken(securityToken))
            {
                response = Ok(new { token = securityToken });
            }
            return response;
        }
    }
}
