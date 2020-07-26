using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.API.Data;
using Microsoft.AspNetCore.Identity;

namespace ComputerShop.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<ApplicationUser> Users { get; }
        Task<List<ApplicationUser>> GetAll();
        Task<IdentityResult> CreateUser(ApplicationUser user, string password);
        Task<IdentityResult> DeleteUser(ApplicationUser user);
        Task<IdentityResult> UpdateUser(ApplicationUser user);
    }
}