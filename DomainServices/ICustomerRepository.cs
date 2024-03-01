using Domain.Dtos;

namespace DomainServices
{
    public interface ICustomerRepository
    {
        Task<List<OrderDto>> GetAllOrders(string customerId);
        Task<OrderDto> GetOrder(int id);
        Task<string> CreateOrder(OrderDto orderDto);
        Task<string> DeleteOrder (int id);
    }
}
