using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.API.Entities;

namespace ComputerShop.Core.Repositories.Interfaces
{
    public interface IProductRepository: IAsyncRepository<Product> 
    {
        IQueryable<Product> Products { get; }
    }
}