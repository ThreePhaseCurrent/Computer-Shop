using System.Threading.Tasks;
using ComputerShop.Core.Entities;

namespace ComputerShop.Core.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken(ApplicationUser user);
        Task<string> RefreshToken(ApplicationUser user);
    }
}