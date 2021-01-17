using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.API.Models;
using ComputerShop.Core.Entities;
using ComputerShop.Core.Services.Interfaces;
using ComputerShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Core.Services
{
    public class ProductService: ProductRepository, IProductService
    {
        public ProductService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProducts(GetProductsRequest productsRequest)
        {
            var pagingSettings = productsRequest.ProductViewParameters;
            var filters = productsRequest.ProductFilters;

            //TODO: to apply filters
            return await Products
                .Where(category => category.CategoryId == filters.ProductCategoryId)
                .OrderBy(n => n.Name)
                .Skip((pagingSettings.PageNumber - 1) * pagingSettings.PageSize)
                .Take(pagingSettings.PageSize)
                .ToListAsync();
        }
    }
}