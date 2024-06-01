//this class contains the methods of security for users (user,role, password)
using TramitesVisas.API.Data;
using TramitesVisas.Shared.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TramitesVisas.API.Helpers;
using TramitesVisas.Shared.DTOs;

namespace TramitesVisas.API.Helpers
{
    public class UserHelper : IUserHelper
    {

        private readonly DataContext _context;
        private UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            this._signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
   
            return await _userManager.CreateAsync( user, password);

        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {

           await _userManager.CreateAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            
            bool roolExist= await _roleManager.RoleExistsAsync(roleName);
            if (!roolExist) { 
            
                await _roleManager.CreateAsync(new IdentityRole{

                    Name=roleName
                });
            
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
