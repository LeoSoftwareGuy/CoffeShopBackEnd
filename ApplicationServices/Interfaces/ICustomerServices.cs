using Domain;
using Domain.Dtos;

namespace ApplicationServices.Interfaces
{
    public interface ICustomerServices
    {
        Task<ServiceResponse<List<OrderDto>>> GetAllOrders(string customerId);
        Task<ServiceResponse<OrderDto>> GetOrder(int id);
        Task<ServiceResponse<bool>> CreateOrder(OrderDto orderDto);
        Task<ServiceResponse<bool>> DeleteOrder(int id);
    }
}
