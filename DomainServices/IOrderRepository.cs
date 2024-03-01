using Domain.Dtos;

namespace DomainServices
{
    public interface IOrderRepository
    {
        Task<List<OrderDto>> GetAllOrders();
        Task<OrderDto> GetOrder(int id);
    }
}
