using ApplicationServices.Interfaces;
using Domain;
using Domain.Dtos;
using DomainServices;

namespace ApplicationServices
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private const string Success = "Success";

        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ServiceResponse<List<OrderDto>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return orders.Count switch
            {
                > 0 => new ServiceResponse<List<OrderDto>>()
                {
                    Data = orders, Message = "Orders are shown", Success = true
                },
                0 => new ServiceResponse<List<OrderDto>>()
                {
                    Data = orders, Message = "No orders were found", Success = true
                },
                _ => new ServiceResponse<List<OrderDto>>()
                {
                    Data = orders, Message = "Something went wrong", Success = false
                }
            };
        }

        public async Task<ServiceResponse<OrderDto>> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrder(id);
            return new ServiceResponse<OrderDto>()
            {
                Data = order,
                Message = "",
                Success = true
            };
        }
    }
}
