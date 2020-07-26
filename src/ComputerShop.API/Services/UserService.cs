using System.Threading.Tasks;
using ComputerShop.API.Data;
using ComputerShop.API.Entities;
using ComputerShop.API.Models;
using ComputerShop.Core.Repositories;
using ComputerShop.Core.Repositories.Interfaces;
using ComputerShop.Core.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ComputerShop.Core.Services
{
    public class UserService : UserRepository, IUserService
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        
        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) 
            : base(userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager) 
            : base(context, userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<SignInResult> UserSingIn(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.UserLogin);
            return  await _signInManager.CheckPasswordSignInAsync(user, 
                login.UserPassword, false);
        }
    }
}