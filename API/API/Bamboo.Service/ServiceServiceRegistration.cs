using Bamboo.Application.Infrastructure.Service.RandomToken;
using Bamboo.Service.RandomToken;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bamboo.Service
{
    public static class ServiceServiceRegistration
    {
        public static void AddServiceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITokenGenerator, TokenGenerator>();
        }
    }
}
