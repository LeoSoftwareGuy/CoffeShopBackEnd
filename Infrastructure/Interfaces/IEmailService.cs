using Domain.Dtos;

namespace Infrastructure.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(OrderDto order);
    }
}
