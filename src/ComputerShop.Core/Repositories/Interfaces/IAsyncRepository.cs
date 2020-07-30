using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ComputerShop.Core.Repositories.Interfaces
{
    /// <typeparam name="T">Entity</typeparam>
    public interface IAsyncRepository<T>
    {
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task AddRange(IList<T> entityRange);
        Task Update(T entity);
        Task UpdateRange(IList<T> entityRange);
        Task Remove(T entity);
        Task RemoveRange(IList<T> entityRange);
    }
}