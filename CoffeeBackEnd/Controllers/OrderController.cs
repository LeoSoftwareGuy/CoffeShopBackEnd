using ApplicationServices.Interfaces;
using Domain;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeBackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OrderDto>>>> GetAllOrders()
        {
            var orders = await _orderServices.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("order/{id}")]
        public async Task<ActionResult<ServiceResponse<OrderDto>>> GetOrder(int id)
        {
            var order = await _orderServices.GetOrder(id);
            return Ok(order);
        }
    }
}
