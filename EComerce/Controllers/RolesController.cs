using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using EComerce.ActionFilter;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> GetAll([FromQuery]string? RoleName) {
          var result= await _roleService.GetAll(predicate:x=>x.RoleName.Contains(RoleName)||RoleName==null);
            return Ok(result);
        }
        [HttpPost("Add")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Add([FromBody]Roles role)
        {
            var result = await _roleService.Add(role);
            return Ok(result);
        }
        [HttpGet("RolePermessions/{Id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public  IActionResult GetPermessionForRule(int Id)
        {
            var result =  _roleService.GetPermessionForRule(Id);
            return Ok(result);
        }
        [HttpPost("SetPermession")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult SetPermessionForRule([FromBody] AddRolePermessionDto ARP)
        {
             _roleService.SetPermessionForRule(ARP.RoleId, ARP.PermessionId);
            return Ok();
        }
        [HttpDelete("Delete/{Id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Delete(int Id) {
            return Ok(await _roleService.DeleteById(Id));
        }
        [HttpDelete("Delete/{RoleId}/{PermessionId}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> DeleteRolePermession(int RoleId,int PermessionId) {
            _roleService.DeleteRolePermession(RoleId, PermessionId);
            return Ok();
        }
    }
}
