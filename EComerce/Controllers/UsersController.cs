using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Domain.Models.filters;
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
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] UserFilter filter) {
            var users = await _userService.GetAll(predicate: x => (x.Name.Contains(filter.Name) || filter.Name == null) && (x.Email.Contains(filter.Email) ||filter.Email==null)&& (x.Roles.RoleName.Contains(filter.RoleName) || filter.RoleName == null));
            return Ok(users);
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id) {

            return Ok(await _userService.GetById(Id));
        }
    }
}
