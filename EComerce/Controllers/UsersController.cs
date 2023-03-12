using AutoMapper;
using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Domain.Models.filters;
using EComerce.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly   IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> GetAll([FromQuery] UserFilter filter) {
            var users = await _userService.GetAll(predicate: x => (x.Name.Contains(filter.Name) || filter.Name == null) && (x.Email.Contains(filter.Email) ||filter.Email==null)&& (x.Roles.RoleName.Contains(filter.RoleName) || filter.RoleName == null));
            return Ok(users);
        }
        [HttpGet("GetById/{Id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> GetById(int Id) {

            return Ok(await _userService.FirstOrDefult(x=>x.Id == Id));
        }
        [HttpPut("Update")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public  IActionResult Update([FromBody] Users user) {

            return Ok( _userService.Update(user));
        }
        [HttpDelete("Delete/{Id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Delete(int Id) {
            return Ok( await _userService.DeleteById(Id));
        }
    }
}
