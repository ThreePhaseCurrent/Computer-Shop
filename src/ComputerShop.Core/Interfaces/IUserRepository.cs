using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace ComputerShop.Core.Interfaces
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