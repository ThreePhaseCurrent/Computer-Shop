using System.Threading.Tasks;
using ComputerShop.Core.Repositories;
using ComputerShop.Core.Repositories.Interfaces;
using ComputerShop.Core.Services;
using ComputerShop.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerShop.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(ITokenService), typeof(TokenService));
        }
    }
}