using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerShop.Core.Repositories.Interfaces
{
    /// <typeparam name="T">Entity</typeparam>
    public interface IAsyncRepository<T>
    {
        Task<List<T>> GetAll();
    }
}