using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAEA.Application.Services;
using SAEA.Application.Services.Interfaces;
using SAEA.Domain.Repositories;
using SAEA.Domain.Services;
using SAEA.Domain.Services.Interfaces;
using SAEA.Infrastructure.Repositories;


namespace SAEA.IoC.Configs
{
    public static class AppClassesConfig
    {
        public static void AddAppClasses(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPavilionRepository, PavilionRepository>();
            services.AddScoped<IPavilionAppService, PavilionAppService>();
            services.AddScoped<IPavilionService, PavilionService>();
        }
    }
}
