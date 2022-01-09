using AttributeService.Core.Interfaces.Repositories;
using AttributeService.Core.Interfaces.Services;
using AttributeService.Core.Services;
using AttributeService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using AttributeService.Infrastructure.Repositories;

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
            attributeDbConnectionString = configuration.GetConnectionString("Attribute");

            //
            services.AddDbContext<AttributeDbContext>(
                optionsAction: options => options.UseSqlServer(attributeDbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IAttributeService, Core.Services.AttributeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAttributeRepository, AttributeRepository>();
            services.AddHttpClient();
            return services;
        }
    }
}
