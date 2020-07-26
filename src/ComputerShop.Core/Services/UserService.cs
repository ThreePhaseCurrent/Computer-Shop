using ComputerShop.API.Entities;
using ComputerShop.Core.Repositories;
using ComputerShop.Core.Repositories.Interfaces;
using ComputerShop.Core.Services.Interfaces;

namespace ComputerShop.Core.Services
{
    public class UserService : UserRepository, IUserRepository
    {
        public UserService(ApplicationDbContext context) : base(context)
        {
        }
    }
}