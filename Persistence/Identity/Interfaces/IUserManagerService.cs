using Domain;
using Domain.Dtos.Identity;
using Domain.Models;

namespace Persistence.Identity.Interfaces
{
    public interface IUserManagerService
    {
        Task<ServiceResponse<dynamic>> Login(LoggingUser user);
        Task<ApplicationUser> FindUserByEmail(string email);
        Task<Customer> GetUserInformation(string id);
        Task<ServiceResponse<string>> CreateUser(UserToBeRegistered toBeRegistered);
        Task<string> DeleteUser(string userId);
    }
}
