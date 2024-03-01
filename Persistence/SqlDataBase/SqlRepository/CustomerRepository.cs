using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Dtos;
using Domain.Models;
using DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Persistence.SqlDataBase.SqlRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CoffeeBackEndDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(CoffeeBackEndDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> GetAllOrders(string customerId)
        {
            var orders = await _dbContext.Orders
                .Where(o => o.CustomerId.Equals(customerId))
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return orders;
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            var order = await _dbContext.Orders
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id.Equals(id));

            return order;
        }

        public async Task<string> CreateOrder(OrderDto orderDto)
        {
            if (!orderDto.OrderItems.Any())
            {
                return "No orders were made!";
            }

            try
            {
                var newOrder = new Order
                {
                    CustomerId = orderDto.CustomerId,
                    OrderDate = DateTime.Now,
                    TotalPrice = orderDto.TotalPrice,
                    ShipAddress = orderDto.ShipAddress,
                    ShipCity = orderDto.ShipCity,
                    ShipCountry = orderDto.ShipCountry,
                    ShipCounty = orderDto.ShipCounty,
                    ShipPostalCode = orderDto.ShipPostalCode,
                    OrderItems = orderDto.OrderItems.Select(orderItemDto => new OrderItem
                    {
                        MenuItemId = orderItemDto.MenuItemId,
                        Quantity = orderItemDto.Quantity,
                        Price = orderItemDto.Price,
                        Size = orderItemDto.Size,
                    }).ToList()
                };

                _dbContext.Orders.Add(newOrder);
                await _dbContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> DeleteOrder(int id)
        {
            try
            {
                var entity = await _dbContext.Orders.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception("Deletion is not possible as entity does not exist");
                }

                _dbContext.Orders.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
