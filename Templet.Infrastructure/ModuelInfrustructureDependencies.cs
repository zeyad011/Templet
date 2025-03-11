using Templet.Infrastructure.InfrustructureBase;
using Templet.Infrastructure.Repositories;
using Templet.Infrastructure.Abstracts;
using Microsoft.Extensions.DependencyInjection;


namespace Templet.Infrastructure
{
    public static class ModuelInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            return services;
        }
    }
}
