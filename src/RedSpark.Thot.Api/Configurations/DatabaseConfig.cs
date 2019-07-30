using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RedSpark.Thot.Api.Application.Extensions;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using RedSpark.Thot.Api.Infra.CrossCutting.Settings;
using RedSpark.Thot.Api.Infra.Data.EF.Context;
using System.Text;

namespace RedSpark.Thot.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var host = configuration["DBHOST"] ?? "localhost";
            var port = configuration["DBPORT"] ?? "1433";
            var password = configuration["DBPASSWORD"] ?? "@#M1cr0s0ftD0tN3t#@";

            // Reference: https://docs.microsoft.com/pt-br/ef/core/what-is-new/ef-core-2.0#dbcontext-pooling
            services.AddDbContextPool<ThotContext>(options => 
                options.UseSqlServer($"Data Source={host},{port};Initial Catalog=Thot;Persist Security Info=True;User ID=sa;Password={password}"));

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<ThotContext>()
                .AddErrorDescriber<IdentityCustomMessage>()
                .AddDefaultTokenProviders();
            
            return services;
        }
    }
}
