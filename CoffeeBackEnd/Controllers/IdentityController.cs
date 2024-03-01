using Domain.Dtos.Identity;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Identity.Interfaces;

namespace CoffeeBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IUserManagerService _userManagerService;

        public IdentityController(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<Customer>> GetUsersInfo(string id)
        {
            var customer = await _userManagerService.GetUserInformation(id);

            return Ok(customer);
        }


        [HttpPost("deleteUser/{id}")]
        public async Task<ActionResult<string>> DeleteUser(string id)
        {
            var result = await _userManagerService.DeleteUser(id);
            return Ok(result);
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserToBeRegistered registrationInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManagerService.CreateUser(registrationInfo);
                if (result.Success)
                {
                    return Ok(result.Message);
                }

                return BadRequest(result.Message);
            }

            return BadRequest();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoggingUser loggingUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManagerService.Login(loggingUser);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest("Invalid credentials");

            }

            return BadRequest("Invalid request");
        }
    }
}
