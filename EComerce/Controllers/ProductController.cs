using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() {
            return Ok(await _productService.GetAll());
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id) {
            return Ok(await _productService.FirstOrDefult(predicate: x => x.Id == Id));
        }
        [HttpPut("Update")]
        public IActionResult Update(Products product) { 
            return Ok(_productService.Update(product));
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProductDto product) {
            return Ok(await _productService.Add(product));
        }
    }
}
