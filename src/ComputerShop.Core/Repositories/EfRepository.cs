using System.Collections.Generic;
using System.Threading.Tasks;
using ComputerShop.API.Entities;
using ComputerShop.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        protected EfRepository(){}

        public async Task<List<T>> GetAll() => 
            await _context.Set<T>().ToListAsync();

        public async Task Add(T entity) => 
            await _context.Set<T>().AddAsync(entity);
        

        public async Task AddRange(IList<T> entityRange) =>
            await _context.Set<T>().AddRangeAsync(entityRange);

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(IList<T> entityRange)
        {
            _context.Set<T>().UpdateRange(entityRange);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IList<T> entityRange)
        {
            _context.Set<T>().RemoveRange(entityRange);
            await _context.SaveChangesAsync();
        }
    }
}