using System.Threading.Tasks;
using ComputerShop.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ComputerShop.API.Services.Interfaces
{
    public interface IUserService: IUserRepository
    {
        Task<SignInResult> UserSingIn(string login, string password, bool rememberMe);
    }
}