using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SAEA.IoC.Configs
{
    public static class MapsterConfig
    {
        public static void ConfigureMapster(this IServiceCollection services, IConfiguration configuration)
        {
            TypeAdapterConfig.GlobalSettings.Scan(typeof(IRegister).Assembly);
        }
    }
}
