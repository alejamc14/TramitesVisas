//Interface of the Userhelper
using TramitesVisas.Shared.Entidades;
using Microsoft.AspNetCore.Identity;

namespace TramitesVisas.API.Helpers
{
    public interface IUserHelper
    {
        //define the methods of userhelper
        Task<User>GetUserAsync(string email);
        Task<IdentityResult>AddUserAsync(User user,string password);
        Task  CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user,string roleName);
        Task<bool>IsUserInRoleAsync(User user, string roleName);
    }
}
