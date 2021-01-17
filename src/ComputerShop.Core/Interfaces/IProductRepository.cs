using System;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.Core.Entities;

namespace ComputerShop.Core.Interfaces
{
    public interface IProductRepository: IAsyncRepository<Product> 
    {
        IQueryable<Product> Products { get; }
        Task<Product> GetSpecificProduct(String stockNumber);
    }
}