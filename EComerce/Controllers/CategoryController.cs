using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly  ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var data = await _categoryService.GetAll();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryDto category)
        {
            var data = await _categoryService.Add(category);
            return Ok(data);
        }
        [HttpGet("find")]
        public async Task<IActionResult> FirstOrDefult()
        {
            var data = await _categoryService.FirstOrDefult();
            return Ok(data);
        }
    }
}
