using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using RedSpark.Thot.Api.Infra.Data.EF.Context;

namespace RedSpark.Thot.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ThotContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("ThotSqlServerConnection")));

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<ThotContext>()
                .AddDefaultTokenProviders();
            
            return services;
        }
    }
}
