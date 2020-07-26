using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.API.Data;
using ComputerShop.API.Entities;
using ComputerShop.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public IQueryable<ApplicationUser> Users => _context.Users;
        
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _context.Set<ApplicationUser>().ToListAsync();
        }
    }
}