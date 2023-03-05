using Domain.IService;
using EC.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() {
            return Ok(await _brandService.GetAll());
        }
    }
}
