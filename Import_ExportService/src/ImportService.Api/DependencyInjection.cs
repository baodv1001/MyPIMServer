using Microsoft.EntityFrameworkCore;
using ImportService.Core.Interfaces.Repositories;
using ImportService.Core.Interfaces.Services;
using ImportService.Infrastructure.Context;
using ImportService.Infrastructure.Repositories;
using ImportService.Api;

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

            string importDbConnectionString = string.Empty;
            importDbConnectionString = configuration.GetConnectionString("Import");

            //
            services.AddDbContext<ImportDbContext>(
                optionsAction: options => options.UseSqlServer(importDbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IImportService, ImportService.Core.Services.ImportService>();
            services.AddScoped<IImportFileRepository, ImportRepository>();
            services.AddHttpClient();
            return services;
        }
    }
}
