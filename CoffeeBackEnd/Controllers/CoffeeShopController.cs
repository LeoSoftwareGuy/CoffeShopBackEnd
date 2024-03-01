using ApplicationServices.Interfaces;
using Domain;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeShopController : ControllerBase
    {
        private readonly ICoffeeShopServices _coffeeShopServices;

        public CoffeeShopController(ICoffeeShopServices coffeeShopServices)
        {
            _coffeeShopServices = coffeeShopServices;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ServiceResponse<List<CoffeeBrandDto>>>> GetAllCoffeeBrands()
        {
            return Ok(await _coffeeShopServices.GetAllCoffeeBrands());
        }

        [HttpGet("brands/{id}")]
        public async Task<ActionResult<ServiceResponse<CoffeeBrandDto>>> GetCoffeeBrand(int id)
        {
            var result = await _coffeeShopServices.GetCoffeeBrand(id);
            return Ok(result);
        }

       [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MenuItemDto>>>> GetAllMenu_Items()
        {
            var result = await _coffeeShopServices.GetAllMenu_Items();
            return Ok(result);
        }

        [HttpGet("menuItem/{id}")]
        public async Task<ActionResult<ServiceResponse<MenuItemDto>>> GetMenu_Item(string id)
        {
            var result = await _coffeeShopServices.GetMenu_Item(int.Parse(id));
            return Ok(result);
        }

        [HttpPost]
        [Route("createMenuItem")]
        public async Task<ActionResult<ServiceResponse<bool>>> CreateMenuItem(MenuItemDto menuItemDto)
        {
            var result = await _coffeeShopServices.CreateMenuItem(menuItemDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("deleteMenuItem/{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteMenuItem(int id)
        {
            var result = await _coffeeShopServices.DeleteMenuItem(id);
            return Ok(result);
        }
    }
}
