using System.Threading.Tasks;
using ComputerShop.API.Data;

namespace ComputerShop.Core.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken(ApplicationUser user);
        Task<string> RefreshToken(ApplicationUser user);
    }
}