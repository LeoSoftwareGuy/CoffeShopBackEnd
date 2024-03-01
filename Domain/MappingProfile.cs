using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CoffeeBrand,CoffeeBrandDto>();
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
