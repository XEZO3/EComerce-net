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
    public class CategoryController : ControllerBase
    {
        private readonly  ICategoryService _categoryService;
        private readonly IFileService _fileService;
        public CategoryController(ICategoryService categoryService, IFileService fileService)
        {
            _categoryService = categoryService;
            _fileService = fileService;
        }
        [HttpGet("GetAll")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> GetAll([FromQuery]CategoryFilter filter) {
            var data = await _categoryService.GetAll(predicate:x=>(x.NameEn.Contains(filter.Name) || x.NameAr.Contains(filter.Name) || filter.Name == null) &&(x.DescriptionAr.Contains(filter.Description) || x.DescriptionEn.Contains(filter.Description)|| filter.Description == null)&& (x.IsAvailable == filter.IsAvailable || filter.IsAvailable == null));
            return Ok(data);
        }
        [HttpPost("Add")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Add([FromForm] CategoryDto category)
        {
            var file = Request.Form.Files;
            category.Image = _fileService.uploadfile(file);
            var data = await _categoryService.Add(category);
            return Ok(data);
        }
        [HttpGet("find")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> FirstOrDefult()
        {
            var data = await _categoryService.FirstOrDefult();
            return Ok(data);
        }
        [HttpGet("GetById/{Id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]

        public async Task<IActionResult> GetById(int Id) {
            return Ok(await _categoryService.GetById(Id));
        }
        [HttpPut("Update")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public  IActionResult Update([FromForm]Category category)
        {
            if (category.Image == "empty")
            {
                var file = Request.Form.Files;
                category.Image = _fileService.uploadfile(file);
            }
            return Ok(_categoryService.Update(category));
        }
        [HttpDelete("Delete/{Id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Delete(int Id) {
            return Ok(await _categoryService.DeleteById(Id));
        
        }
    }
}
