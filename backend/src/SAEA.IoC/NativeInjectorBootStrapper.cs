using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAEA.IoC.Configs;

namespace SAEA.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureAppClasses(configuration);

            services.ConfigureSqlServer(configuration);

            services.ConfigureMapster(configuration);
        }
    }
}
