using ApplicationServices.Interfaces;
using Domain;
using Domain.Dtos;
using DomainServices;
using Infrastructure.Interfaces;

namespace ApplicationServices
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;
        private const string Success = "Success";

        public CustomerServices(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public async Task<ServiceResponse<List<OrderDto>>> GetAllOrders(string customerId)
        {
            var orders = await _customerRepository.GetAllOrders(customerId);

            return orders.Count switch
            {
                > 0 => new ServiceResponse<List<OrderDto>>()
                {
                    Data = orders, Message = "Orders are obtained", Success = true
                },
                0 => new ServiceResponse<List<OrderDto>>()
                {
                    Data = null, Message = "No Orders were found", Success = true
                },
                _ => new ServiceResponse<List<OrderDto>>()
                {
                    Data = orders, Message = "Something went wrong", Success = false
                }
            };
        }


        public async Task<ServiceResponse<OrderDto>> GetOrder(int id)
        {
            var order = await _customerRepository.GetOrder(id);

            return new ServiceResponse<OrderDto>()
            {
                Data = order,
                Message = "Order is obtained",
                Success = true
            };
        }


        public async Task<ServiceResponse<bool>> CreateOrder(OrderDto orderDto)
        {
            var tryToCreateOrder = await _customerRepository.CreateOrder(orderDto);
            if (tryToCreateOrder.Equals(Success))
            {
                await _emailService.SendEmail(orderDto);
                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Message = "Order was created",
                    Success = true
                };
            }

            return new ServiceResponse<bool>()
            {
                Data = false,
                Message = tryToCreateOrder,
                Success = false
            };
        }


        public async Task<ServiceResponse<bool>> DeleteOrder(int id)
        {
            var tryToDeleteOrder = await _customerRepository.DeleteOrder(id);
            if (tryToDeleteOrder.Equals(Success))
            {
                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Message = tryToDeleteOrder,
                    Success = true
                };
            }

            return new ServiceResponse<bool>()
            {
                Data = false,
                Message = tryToDeleteOrder,
                Success = false
            };
        }
    }
}
