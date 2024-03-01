using ApplicationServices.Interfaces;
using System;
using Domain;
using Domain.Dtos;
using DomainServices;

namespace ApplicationServices
{
    public class CoffeeShopServices : ICoffeeShopServices
    {
        private readonly ICoffeeShopRepository _coffeeShopRepository;
        private const string Success = "Success";

        public CoffeeShopServices(ICoffeeShopRepository coffeeShopRepository)
        {
            _coffeeShopRepository = coffeeShopRepository;
        }

        public async Task<ServiceResponse<List<CoffeeBrandDto>>> GetAllCoffeeBrands()
        {
            var brands = await _coffeeShopRepository.GetAllCoffeeBrands();
            if (brands.Count > 0)
            {
                return new ServiceResponse<List<CoffeeBrandDto>>()
                {
                    Data = brands,
                    Message = "Data was delivered",
                    Success = true
                };
            }

            return new ServiceResponse<List<CoffeeBrandDto>>()
            {
                Data = brands,
                Message = "No data was found",
                Success = false
            };
        }

        public async Task<ServiceResponse<CoffeeBrandDto>> GetCoffeeBrand(int id)
        {
            var brand = await _coffeeShopRepository.GetCoffeeBrand(id);
            return new ServiceResponse<CoffeeBrandDto>()
            {
                Data = brand,
                Message = "Data was delivered",
                Success = true
            };
        }

        public async Task<ServiceResponse<List<MenuItemDto>>> GetAllMenu_Items()
        {
            var menuItems = await _coffeeShopRepository.GetAllMenu_Items();

            if (menuItems.Count > 0)
            {
                return new ServiceResponse<List<MenuItemDto>>()
                {
                    Data = menuItems,
                    Message = "Data was delivered",
                    Success = true
                };
            }

            return new ServiceResponse<List<MenuItemDto>>()
            {
                Data = menuItems,
                Message = "No data was found",
                Success = false
            };
        }

        public async Task<ServiceResponse<MenuItemDto>> GetMenu_Item(int id)
        {
            var menuItem = await _coffeeShopRepository.GetMenu_Item(id);

            return new ServiceResponse<MenuItemDto>()
            {
                Data = menuItem,
                Message = "Data was delivered",
                Success = true
            };
        }


        public async Task<ServiceResponse<bool>> CreateMenuItem(MenuItemDto menuItemDto)
        {
            var tryToCreate = await _coffeeShopRepository.CreateMenuItem(menuItemDto);
            if (tryToCreate.Equals(Success))
            {
                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Message = "Item was added!",
                    Success = true
                };
            }

            return new ServiceResponse<bool>()
            {
                Data = false,
                Message = tryToCreate,
                Success = false
            };
        }

        public async Task<ServiceResponse<bool>> DeleteMenuItem(int id)
        {
            var tryToDelete = await _coffeeShopRepository.DeleteMenuItem(id);
            if (tryToDelete.Equals(Success))
            {
                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Message = "Item was deleted",
                    Success = true
                };
            }

            return new ServiceResponse<bool>()
            {
                Data = false,
                Message = tryToDelete,
                Success = false
            };
        }
    }
}
