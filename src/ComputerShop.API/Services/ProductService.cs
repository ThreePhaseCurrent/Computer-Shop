using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.API.Entities;
using ComputerShop.API.Models;
using ComputerShop.Core.Repositories;
using ComputerShop.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Core.Services
{
    public class ProductService: ProductRepository, IProductService
    {
        public ProductService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProducts(ProductViewParameters parameters)
        {
            return await GetAll()
            .OrderBy(n => n.Name)
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();
        }
    }
}