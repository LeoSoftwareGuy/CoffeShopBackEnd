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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<ServiceResponse<List<OrderDto>>>> GetAllOrders(string customerId)
        {
            var allOrders = await _customerServices.GetAllOrders(customerId);
            return Ok(allOrders);
        }

        [HttpGet("orders/{id}")]
        public async Task<ActionResult<ServiceResponse<OrderDto>>> GetOrder(int id)
        {
            var result = await _customerServices.GetOrder(id);
            return Ok(result);
        }

        [HttpPost("createOrder")]
        public async Task<ActionResult<ServiceResponse<bool>>> CreateOrder(OrderDto menuItemDto)
        {
            var result = await _customerServices.CreateOrder(menuItemDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("deleteOrder/{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteOrder(int id)
        {
             var result = await _customerServices.DeleteOrder(id);
            return Ok(result);
        }
    }
}
