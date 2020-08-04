using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComputerShop.API.Entities;
using ComputerShop.API.Models;
using ComputerShop.Core.Repositories.Interfaces;

namespace ComputerShop.Core.Services.Interfaces
{
    public interface IProductService: IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(ProductViewParameters parameters);
    }
}