using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductNS.Application.Services;
using ProductNS.Infrastructure;
using System.Reflection;

namespace ProductNS.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();

            services.AddInfrastructureModule(configuration);
            
            return services; 
        }
    }
}
