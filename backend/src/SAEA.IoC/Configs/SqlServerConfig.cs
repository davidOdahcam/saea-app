using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAEA.Infrastructure.Database.Context;

namespace SAEA.IoC.Configs
{
    public static class SqlServerConfig
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SAEAContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptions =>
                    {
                        sqlServerOptions.MigrationsAssembly("SAEA.Infrastructure");
                        sqlServerOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                        );
                    }
                );
            });
        }
    }
}
