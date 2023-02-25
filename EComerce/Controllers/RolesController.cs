using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]string? RoleName) {
          var result= await _roleService.GetAll(predicate:x=>x.RoleName.Contains(RoleName)||RoleName==null);
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]Roles role)
        {
            var result = await _roleService.Add(role);
            return Ok(result);
        }
        [HttpPost("RolePermessions")]
        public  IActionResult GetPermessionForRule([FromBody] int RoleId)
        {
            var result =  _roleService.GetPermessionForRule(RoleId);
            return Ok(result);
        }
        [HttpPost("SetPermession")]
        public IActionResult SetPermessionForRule([FromBody] AddRolePermessionDto ARP)
        {
             _roleService.SetPermessionForRule(ARP.RoleId, ARP.PermessionId);
            return Ok();
        }
    }
}
