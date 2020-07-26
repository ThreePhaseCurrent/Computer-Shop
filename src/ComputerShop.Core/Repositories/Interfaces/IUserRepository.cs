using System.Collections.Generic;
using System.Threading.Tasks;
using ComputerShop.API.Data;

namespace ComputerShop.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAll();
    }
}