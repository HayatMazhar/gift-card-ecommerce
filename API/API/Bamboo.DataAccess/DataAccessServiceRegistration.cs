using Microsoft.Extensions.DependencyInjection;
using Bamboo.Application.Infrastructure.Repository;
using Bamboo.Application.JsonModels;
using Microsoft.Extensions.Configuration;
using Bamboo.DataAccess.Repositories.Department;

namespace Bamboo.DataAccess
{
   public static class DataAccessServiceRegistration
    {


        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region Configuring appsetting.json key to JsonModal class             
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            #endregion

            #region Dependency registration region for repositories
            services.AddScoped<IAsyncProductRepository, ProductRepository>();
            services.AddScoped<IAsyncOrderRepository, OrderRepository>();

            #endregion

            return services;
        }
    }
}
