using Domain.common;
using Domain.IService;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Add")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Add([FromBody]OrderDto order) {

            return Ok(await _orderService.Add(order)); 
        }
        [HttpGet("GetAll")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> GetAll([FromQuery] OrderFilter order)
        {
            return Ok(await _orderService.GetAll());
        }
        [HttpGet("GetMyOrders")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> GetMyOrders()
        {
            return Ok(await _orderService.GetAll(x=>x.CustomerId==SharedIds.CustomerId));
        }
        [HttpPut("UpdateState/{Id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> UpdateState(int Id, [FromForm] string state)
        {
             
            return Ok(await _orderService.UpdateState(Id, state));
        }

    }
}
