using Domain;
using Domain.Dtos;

namespace ApplicationServices.Interfaces
{
    public interface ICoffeeShopServices
    {
        Task<ServiceResponse<List<CoffeeBrandDto>>> GetAllCoffeeBrands();
        Task<ServiceResponse<CoffeeBrandDto>> GetCoffeeBrand(int id);
        Task<ServiceResponse<List<MenuItemDto>>> GetAllMenu_Items();
        Task<ServiceResponse<MenuItemDto>> GetMenu_Item(int id);
        Task<ServiceResponse<bool>> CreateMenuItem(MenuItemDto menuItemDto);
        Task<ServiceResponse<bool>> DeleteMenuItem(int id);
    }
}
