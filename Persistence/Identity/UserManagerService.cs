using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Domain.Dtos.Identity;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Identity.Interfaces;
using Persistence.SqlDataBase;

namespace Persistence.Identity
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CoffeeBackEndDbContext _context;

        public UserManagerService(UserManager<ApplicationUser> userManager, CoffeeBackEndDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<ServiceResponse<dynamic>> Login(LoggingUser userToLogin)
        {
            var user = await _userManager.FindByEmailAsync(userToLogin.Email);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, userToLogin.Password);
                if (result)
                {
                    var roles = from ur in _context.UserRoles
                        join r in _context.Roles on ur.RoleId equals r.Id
                        where ur.UserId == user.Id
                        select new { ur.UserId, ur.RoleId, r.Name };

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userToLogin.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(JwtRegisteredClaimNames.Nbf,
                            new DateTimeOffset(DateTime.Now)
                                .ToUnixTimeSeconds()
                                .ToString()),
                        new Claim(JwtRegisteredClaimNames.Exp,
                            new DateTimeOffset(DateTime.Now.AddHours(2))
                                .ToUnixTimeSeconds()
                                .ToString())
                    };

                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }

                    var token = new JwtSecurityToken(
                        new JwtHeader(
                            new SigningCredentials(
                                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyIsSecret")),
                                SecurityAlgorithms.HmacSha256)),
                        new JwtPayload(claims));

                    return new ServiceResponse<dynamic>()
                    {
                        Data = new
                        {
                            Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Email = userToLogin.Email
                        },
                        Message = user.Id,
                        Success = true
                    };
                }

                else
                {
                    return new ServiceResponse<dynamic>()
                    {
                        Data = "",
                        Message = "Password does not match",
                        Success = false
                    };
                }
            }

            return new ServiceResponse<dynamic>()
            {
                Data = "",
                Message = "You are not registered",
                Success = false
            };
        }

        public async Task<ApplicationUser> FindUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<Customer> GetUserInformation(string id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<ServiceResponse<string>> CreateUser(UserToBeRegistered toBeRegistered)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = toBeRegistered.Email,
                UserName = toBeRegistered.FirstName
            };

            var result = await _userManager.CreateAsync(user, toBeRegistered.Password);

            if (result.Succeeded)
            {
                var customer = new Customer()
                {
                    Id = user.Id,
                    FirstName = toBeRegistered.FirstName,
                    LastName = toBeRegistered.LastName,
                    Email = toBeRegistered.Email,
                    Password = toBeRegistered.Password,
                    Number = toBeRegistered.Number
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return new ServiceResponse<string>()
                {
                    Data = "",
                    Message = "Great to meet you, coffee man!",
                    Success = true
                };
            }
            else
            {
                return new ServiceResponse<string>()
                {
                    Data = "",
                    Message = "Something Went Wrong, please try again later!",
                    Success = false
                };
            }
        }


        public async Task<string> DeleteUser(string userId)
        {
            var user = await _context.Customers.FindAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(_userManager.Users.SingleOrDefault(u => u.Id == userId)!);
                _context.Customers.Remove(user);
                return "Success";
            }

            return "Did not work";
        }
    }
}
