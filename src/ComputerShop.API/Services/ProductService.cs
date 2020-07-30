using ComputerShop.API.Entities;
using ComputerShop.Core.Repositories;
using ComputerShop.Core.Services.Interfaces;

namespace ComputerShop.Core.Services
{
    public class ProductService: ProductRepository, IProductService
    {
        public ProductService(ApplicationDbContext context) : base(context)
        {
        }
    }
}