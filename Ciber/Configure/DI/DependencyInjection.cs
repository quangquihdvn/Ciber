using Ciber.Infrastructure.EF;
using Ciber.Infrastructure.Infrastructure.EF;
using Ciber.Models.Entities;
using Ciber.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ciber.Configure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DbContext
            services.AddDbContext<CiberDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MainDatabase")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
