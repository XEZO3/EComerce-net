﻿using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Domain.Models.filters;
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
        public async Task<IActionResult> GetAll([FromQuery]CategoryFilter filter) {
            var data = await _categoryService.GetAll(predicate:x=>(x.NameEn.Contains(filter.Name) || x.NameAr.Contains(filter.Name) || filter.Name == null) &&(x.DescriptionAr.Contains(filter.Description) || x.DescriptionEn.Contains(filter.Description)|| filter.Description == null));
            return Ok(data);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] CategoryDto category)
        {
            var file = Request.Form.Files;
            category.Image = _fileService.uploadfile(file);
            var data = await _categoryService.Add(category);
            return Ok(data);
        }
        [HttpGet("find")]
        public async Task<IActionResult> FirstOrDefult()
        {
            var data = await _categoryService.FirstOrDefult();
            return Ok(data);
        }
        [HttpGet("GetById/{Id}")]

        public async Task<IActionResult> GetById(int Id) {
            return Ok(await _categoryService.GetById(Id));
        }
        [HttpPut("Update")]
        public  IActionResult Update(Category category)
        {
            return Ok(_categoryService.Update(category));
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id) {
            return Ok(await _categoryService.DeleteById(Id));
        
        }
    }
}
