using Domain.common;
using EComerce.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace EComerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        
        [HttpGet]
        
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult testo() {
           // var token = Request.Headers.Authorization[0].Replace("Bearer ","");
            //var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            //string user = jwt.Claims.First(c => c.Type == "role").Value;
            
            return Ok();
            
        }
    }
}
