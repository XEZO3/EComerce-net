﻿using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Domain.Models.filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EComerce.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IFileService _fileService;
        public ProductController(IProductService productService, IFileService fileService)
        {
            _productService = productService;
            _fileService = fileService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]ProductFilter filter) {
            //var tt = new List<Products>() { new Products { Id=1}, new Products { Id = 2 } };
            //return Ok(await _productService.GetAll(x=>tt.Select(z=>z.Id).Contains(x.Id)));
            return Ok(await _productService.GetAll(predicate:x=>(x.NameAr.Contains(filter.Name)||x.NameEn.Contains(filter.Name)||filter.Name==null)&& (x.DescriptionAr.Contains(filter.Description) || x.DescriptionEn.Contains(filter.Description) || filter.Description == null)&&(x.Avilability==filter.Avilability||filter.Avilability==null)));
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id) {
            return Ok(await _productService.FirstOrDefult(predicate: x => x.Id == Id));
        }
        [HttpPut("Update")]
        public IActionResult Update([FromForm]Products product) {
            if (product.Image == "empty")
            {
                var file = Request.Form.Files;
                product.Image = _fileService.uploadfile(file);
            }
            return Ok(_productService.Update(product));
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm]ProductDto product) {
            var file = Request.Form.Files;
            product.Image = _fileService.uploadfile(file);
            return Ok(await _productService.Add(product));
        }
        [HttpPost("testo")]
        public IActionResult testo([FromForm]ProductDto text) {
            var tt = Request.Form.Files;
            return Ok();
        }
        [HttpPost("GetCartItem")]
        public async Task<IActionResult> GetCartItems([FromForm]string cart) {
             List<CartDto> obj = JsonConvert.DeserializeObject<List<CartDto>>(cart);
            return Ok(await _productService.GetAll(x=> obj.Select(z=>z.Id).Contains(x.Id)));
           //return Ok(obj);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteById(int Id) {
            return Ok(await _productService.DeleteById(Id));
          }
    }
}
