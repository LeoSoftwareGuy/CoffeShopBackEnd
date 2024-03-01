using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Dtos;
using DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Persistence.SqlDataBase.SqlRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CoffeeBackEndDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(IMapper mapper, CoffeeBackEndDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<List<OrderDto>> GetAllOrders()
        {
            var orders = await _dbContext.Orders
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
    }
}
