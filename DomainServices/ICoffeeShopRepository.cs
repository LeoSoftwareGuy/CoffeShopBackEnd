using Domain.Dtos;

namespace DomainServices
{
    public interface ICoffeeShopRepository
    {
        Task<List<CoffeeBrandDto>> GetAllCoffeeBrands();
        Task<CoffeeBrandDto> GetCoffeeBrand(int id);
        Task<List<MenuItemDto>> GetAllMenu_Items();
        Task<MenuItemDto> GetMenu_Item(int id);
        Task<string> CreateMenuItem(MenuItemDto menuItem);
        Task<string> DeleteMenuItem(int id);
    }
}