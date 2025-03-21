
using EazyFD.Domain.repository;
using EazyFD.Infrastructure.repository;
using Microsoft.Extensions.DependencyInjection;

namespace EazyFD.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDepositRepository, DepositRepository>();
            return services;
        }
    }
}
