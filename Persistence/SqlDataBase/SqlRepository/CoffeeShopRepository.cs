using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Dtos;
using Domain.Models;
using DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Persistence.SqlDataBase.SqlRepository
{
    public class CoffeeShopRepository : ICoffeeShopRepository
    {
        private readonly CoffeeBackEndDbContext _dbContext;
        private readonly IMapper _mapper;

        public CoffeeShopRepository(CoffeeBackEndDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CoffeeBrandDto>> GetAllCoffeeBrands()
        {
            var brands = await _dbContext.CoffeeBrands
                              .ProjectTo<CoffeeBrandDto>(_mapper.ConfigurationProvider)
                              .ToListAsync();
            return brands;
        }

        public async Task<CoffeeBrandDto> GetCoffeeBrand(int id)
        {
            var brand = await _dbContext.CoffeeBrands.ProjectTo<CoffeeBrandDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            return brand;
        }

        public async Task<List<MenuItemDto>> GetAllMenu_Items()
        {
            var menuItems = await _dbContext.MenuItems
                .ProjectTo<MenuItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return menuItems;
        }

        public async Task<MenuItemDto> GetMenu_Item(int id)
        {
            var menuItem = await _dbContext.MenuItems
                    .ProjectTo<MenuItemDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(m => m.Id.Equals(id));

            return menuItem;
        }

        public async Task<string> CreateMenuItem(MenuItemDto menuItemDto)
        {
            try
            {
                var menuItem = new MenuItem
                {
                    CoffeeBrandId = menuItemDto.CoffeeBrandId,
                    Name = menuItemDto.Name,
                    SmallPackagePrice = menuItemDto.SmallPackagePrice,
                    MediumPackagePrice = menuItemDto.MediumPackagePrice,
                    LargePackagePrice = menuItemDto.LargePackagePrice,
                    ImageUrl = menuItemDto.ImageUrl,
                    Description = menuItemDto.Description,
                    Origin = menuItemDto.Origin,
                };

                _dbContext.MenuItems.Add(menuItem);
                await _dbContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> DeleteMenuItem(int id)
        {
            try
            {
                var entity = await _dbContext.MenuItems.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception("Deletion is not possible as entity does not exist");
                }

                _dbContext.MenuItems.Remove(entity);
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
