using Microsoft.EntityFrameworkCore;
using AssetsService.Core.Interfaces.Repositories;
using AssetsService.Core.Interfaces.Services;
using AssetsService.Infrastructure.Context;
using AssetsService.Infrastructure.Repositories;

namespace AttributeService.Api
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

            string attributeDbConnectionString = string.Empty;
            attributeDbConnectionString = configuration.GetConnectionString("Assets");

            //
            services.AddDbContext<AssetsDbContext>(
                optionsAction: options => options.UseSqlServer(attributeDbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IAssetsService, AssetsService.Core.Services.AssetsService>();
            services.AddScoped<IAssetsRepository, AssetsRepository>();
            services.AddHttpClient();
            return services;
        }
    }
}
