using AirbnbClone.Interfaces;
using AirbnbClone.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirbnbClone.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderable _order;
        public OrderController(IOrderable order)
        {
            _order = order;
        }

        [HttpGet]
        public async Task<IActionResult> Orders(string user)
        {
            var orders = await _order.Get(user);
            if(orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        [HttpGet]
        public async Task<IActionResult>  Order(int id)
        {
            var order  = await _order.Get(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto dto)
        {
            var created = await _order.Create(dto);

            if (created == null) return BadRequest();
            return Created();
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderDto dto)
        {
            var updated = await _order.Update(dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
    }
}
