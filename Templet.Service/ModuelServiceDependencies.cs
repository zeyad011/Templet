using Templet.Service.Abstract;
using Templet.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;
namespace Templet.Service
{
    public static class ModuelServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            return services;
        }
    }
}
