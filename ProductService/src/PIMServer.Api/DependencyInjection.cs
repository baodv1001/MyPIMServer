using Microsoft.EntityFrameworkCore;
using PIMServer.Core.Interfaces.Repositories;
using PIMServer.Core.Interfaces.Services;
using PIMServer.Core.Services;
using PIMServer.Infrastructure.Context;
using PIMServer.Infrastructure.Repositories;

namespace PIMServer.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection (this IServiceCollection services, IConfiguration configuration)
        {
            if(services == null)
            {
                throw new ArgumentNullException (nameof (services));
            }    

            if (configuration == null)
            {
                throw new ArgumentNullException (nameof (configuration));
            }


            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

            string productDbConnectionString = string.Empty;
            string storeProductDbConnectionString = string.Empty;
            string attributeDbConnectionString = string.Empty;
            productDbConnectionString = configuration.GetConnectionString("Product");
            storeProductDbConnectionString = configuration.GetConnectionString("StoreProduct");
            attributeDbConnectionString = configuration.GetConnectionString("Attribute");

            //
            services.AddDbContext<AttributeDbContext>(
                optionsAction: options => options.UseSqlServer(attributeDbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddDbContext<ProductDbContext>(
                optionsAction: options => options.UseSqlServer(productDbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddHttpClient();
            return services;
        }
    }
}
