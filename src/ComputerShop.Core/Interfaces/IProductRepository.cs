using System.Linq;
using ComputerShop.Core.Entities;

namespace ComputerShop.Core.Interfaces
{
    public interface IProductRepository: IAsyncRepository<Product> 
    {
        IQueryable<Product> Products { get; }
    }
}