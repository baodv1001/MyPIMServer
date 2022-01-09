using Microsoft.EntityFrameworkCore;
using AuthService.Infrastructure.Context;
using AuthenticationService.Core.Interfaces.Services;

namespace AuthenticationService.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }


            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

            string authDbConnectionString = string.Empty;
            authDbConnectionString = configuration.GetConnectionString("Auth");

            //
            services.AddDbContext<AuthDbContext>(
                optionsAction: options => options.UseSqlServer(authDbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IAuthService, AuthService.Core.Services.AuthService>();
            services.AddHttpClient();
            return services;
        }
    }
}
