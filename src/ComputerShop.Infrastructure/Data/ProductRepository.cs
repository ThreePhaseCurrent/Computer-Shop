using System.Linq;
using System.Threading.Tasks;
using ComputerShop.Core.Entities;
using ComputerShop.Core.Interfaces;

namespace ComputerShop.Infrastructure.Data
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Product;
        public async Task<Product> GetSpecificProduct(string stockNumber)
        {
            //TODO: return product by stock number
            return new Product();
        }
    }
}