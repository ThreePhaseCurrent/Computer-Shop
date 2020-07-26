using System.Collections.Generic;
using System.Threading.Tasks;
using ComputerShop.API.Entities;
using ComputerShop.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Core.Repositories
{
    /// <summary>
    /// Universal repository
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public class EfRepository<T> : IAsyncRepository<T> where T: class
    {
        private readonly ApplicationDbContext _context;

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll() => 
            await _context.Set<T>().ToListAsync();
    }
}