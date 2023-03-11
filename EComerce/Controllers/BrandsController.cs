using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Domain.Models.filters;
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
        private readonly IFileService _fileService;
        public BrandsController(IBrandService brandService, IFileService fileService)
        {
            _brandService = brandService;
            _fileService = fileService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]BrandFilter filter) {
            return Ok(await _brandService.GetAll(predicate:x=>(x.NameAr.Contains(filter.Name)||x.NameEn.Contains(filter.Name)||string.IsNullOrEmpty(filter.Name))&&(x.IsAvailable==filter.IsAvailable||filter.IsAvailable==null)));
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id) { 
        return Ok(await _brandService.GetById(Id));
        }
        [HttpPut("Update")]
        public IActionResult Update([FromForm]Brands brand)
        {
            if (brand.Image == "empty") {
                var file = Request.Form.Files;
                brand.Image = _fileService.uploadfile(file);
            }
            return Ok( _brandService.Update(brand));
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] BrandDto brand) {
            var file = Request.Form.Files;
            brand.Image = _fileService.uploadfile(file);
            return Ok( await _brandService.Add(brand));
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id) {
            return Ok(await _brandService.DeleteById(Id));
        }
    }
}
