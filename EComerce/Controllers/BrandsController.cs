﻿using Domain.IService;
using Domain.Models;
using Domain.Models.Dto;
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
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id) { 
        return Ok(await _brandService.GetById(Id));
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody]Brands brand)
        {
            return Ok( _brandService.Update(brand));
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] BrandDto brand) { 
        return Ok( await _brandService.Add(brand));
        }
    }
}