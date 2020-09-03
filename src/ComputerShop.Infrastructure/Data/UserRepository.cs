using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.Core.Entities;
using ComputerShop.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        public IQueryable<ApplicationUser> Users => _context.Users;
        
        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        } 
        
        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _context.Set<ApplicationUser>().ToListAsync();
        }
        
        public async Task<IdentityResult> CreateUser(ApplicationUser user, string password) =>
            await _userManager.CreateAsync(user, password);

        public async Task<IdentityResult> UpdateUser(ApplicationUser user) =>
            await _userManager.UpdateAsync(user);
        
        public async Task<IdentityResult> DeleteUser(ApplicationUser user) =>
            await _userManager.DeleteAsync(user);
    }
}