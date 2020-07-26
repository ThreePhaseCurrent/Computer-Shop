using System.Threading.Tasks;
using ComputerShop.API.Data;
using ComputerShop.API.Models;
using ComputerShop.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ComputerShop.Core.Services.Interfaces
{
    public interface IUserService: IUserRepository
    {
        Task<SignInResult> UserSingIn(Login login);
    }
}