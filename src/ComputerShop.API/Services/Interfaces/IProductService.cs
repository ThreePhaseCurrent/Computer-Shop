using System.Collections.Generic;
using System.Threading.Tasks;
using ComputerShop.API.Models;
using ComputerShop.Core.Entities;
using ComputerShop.Core.Interfaces;

namespace ComputerShop.Core.Services.Interfaces
{
    public interface IProductService: IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(GetProductsRequest productsRequest);
    }
}