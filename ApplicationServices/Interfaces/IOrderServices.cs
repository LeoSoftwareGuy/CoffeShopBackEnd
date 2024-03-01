using Domain;
using Domain.Dtos;

namespace ApplicationServices.Interfaces
{
    public interface IOrderServices
    {
        Task<ServiceResponse<List<OrderDto>>> GetAllOrders();
        Task<ServiceResponse<OrderDto>> GetOrder(int id);
    }
}
