using ComputerShop.API.Services;
using ComputerShop.API.Services.Interfaces;
using ComputerShop.Core.Interfaces;
using ComputerShop.Core.Services;
using ComputerShop.Core.Services.Interfaces;
using ComputerShop.Infrastructure.Data;
using ComputerShop.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerShop.API.Extensions
{
    /// <summary>
    /// Extensions for service collection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            //logger
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            
            //reositories
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            
            //services
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
        }
    }
}