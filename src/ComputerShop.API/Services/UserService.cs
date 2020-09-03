using System.Threading.Tasks;
using ComputerShop.API.Services.Interfaces;
using ComputerShop.Core.Entities;
using ComputerShop.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace ComputerShop.API.Services
{
    public class UserService : UserRepository, IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        
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
        public async Task<SignInResult> UserSingIn(string login, string password, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(login);
            return  await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }
    }
}