using Mapster;
using SAEA.IoC;

namespace SAEA.API
{
    public static class Program
    {
        private static readonly string _corsPolicyName = "_myCorsPolicyName";

        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                AddServices(builder);

                var app = builder.Build();

                ConfigureServices(app);

                app.Run();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[FATAL ERROR] Failure on initialization: {ex.Message}");
                Console.Error.WriteLine(ex.StackTrace);
            }
        }

        public static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: _corsPolicyName,
                    policy =>
                    {
                        var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

                        if (allowedOrigins is not null && allowedOrigins.Length > 0)
                        {
                            policy.WithOrigins(allowedOrigins)
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                        }
                    });
            });

            builder.Services.AddOpenApi();

            builder.Services.AddMapster();

            NativeInjectorBootStrapper.RegisterServices(builder.Services, builder.Configuration);
        }

        public static void ConfigureServices(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseCors(_corsPolicyName);

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}