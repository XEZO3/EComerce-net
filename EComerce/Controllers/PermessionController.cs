using Domain.IService;
using Domain.Models;
using EComerce.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermessionController : ControllerBase
    {
        private readonly IPermessionService _permessionService;
        public PermessionController(IPermessionService permessionService)
        {
            _permessionService = permessionService;
        }
        [HttpGet("GetAll")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public  async Task<IActionResult> GetAll(){

            return Ok(await _permessionService.GetAll());
        }
        [HttpPost("Add")]
        [Authorize(Roles ="SuperAdmin")]
        
        public async Task<IActionResult> Add([FromBody]Permessions permession)
        {
            return Ok(await _permessionService.Add(permession));
        }
   }
}
