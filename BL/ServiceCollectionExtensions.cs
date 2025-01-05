using DL.Models;
using DL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<FlowerSalesCompanyDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register your repositories
            services.AddScoped<ProductRepository>();
            services.AddScoped<SystemRepository>();
            // Add other repositories as needed

            // Register your services
            services.AddScoped<ProductService>();
            services.AddScoped<SystemService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<MaterialService>();
            services.AddScoped<StoreService>();
            // Add other services as needed

            return services;
        }
    }
}
