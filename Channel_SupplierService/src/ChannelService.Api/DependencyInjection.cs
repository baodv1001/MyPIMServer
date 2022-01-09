using ChannelService.Core.Interfaces.Repositories;
using ChannelService.Core.Interfaces.Services;
using ChannelService.Core.Services;
using ChannelService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ChannelService.Infrastructure.Repositories;

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
            services.AddDbContext<ChannelDbContext>(
                optionsAction: options => options.UseSqlServer(attributeDbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IChannelService, ChannelService.Core.Services.ChannelService>();
            services.AddScoped<ISupplierService, ChannelService.Core.Services.SupplierService >();
            services.AddScoped<IChannelRepository, ChannelRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddHttpClient();
            return services;
        }
    }
}
