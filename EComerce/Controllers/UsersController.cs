using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto user) {
          var add = await  _userService.Register(user);
            return Ok(add);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            var add = await _userService.Login(user);
            return Ok(add);
        }
    }
}
