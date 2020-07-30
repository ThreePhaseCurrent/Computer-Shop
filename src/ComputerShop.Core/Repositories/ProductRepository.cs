using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.API.Entities;
using ComputerShop.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Core.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;
    }
}