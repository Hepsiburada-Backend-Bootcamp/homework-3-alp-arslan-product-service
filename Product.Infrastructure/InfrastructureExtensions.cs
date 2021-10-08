using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductNS.Domain.Repositories;
using ProductNS.Infrastructure.Context;
using ProductNS.Infrastructure.Repositories;

namespace ProductNS.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            /*
            services.AddDbContext<ProductContext>(opt =>
                                   opt.UseInMemoryDatabase("Products"));
            */

            services.AddDbContext<ProductContext>(options =>
                options
                    .UseNpgsql(configuration.GetConnectionString("ProductContext"),
                        b => b.MigrationsAssembly("ProductApi"))
                    .UseSnakeCaseNamingConvention()
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                    .EnableSensitiveDataLogging()
            );

            //Displays detailed error pages
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}
