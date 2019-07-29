using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RedSpark.Thot.Api.Infra.CrossCutting.Settings;
using RedSpark.Thot.Api.Infra.IoC;
using System;

namespace RedSpark.Thot.Api.Configurations
{
    public static class WebApiConfig
    {
        public static IMvcBuilder AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            
            var builder = services
                .AddMvcCore(options => { options.EnableEndpointRouting = true; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            builder.AddJsonFormatters(o =>
            {
                o.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
            builder.AddApiExplorer();
            builder.AddCors();
                       

            // Add Identity Configuration
            services.AddDataBaseConfiguration(configuration);

            //builder.AddMySwagger();
            // Register Dependency
            services.Resolve();

            return new MvcBuilder(builder.Services, builder.PartManager);
        }

        public static IMvcBuilder AddWebApi(this IServiceCollection services, IConfiguration configuration, Action<MvcOptions> setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            var builder = services
                .AddWebApi(configuration)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
            builder.Services.Configure(setupAction);

            return builder;
        }

        public static IApplicationBuilder AddMyConfigApp(this IApplicationBuilder app, IHostingEnvironment env, MySettings mySettings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Configurando CORS
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            // Configurando acesso estático ao arquivo de log (após gravar log no banco remover)
            // https://github.com/aspnet/AspNetCore/blob/507a765dfb078f446c445318e7b55ad9f7f5cbe0/src/Middleware/StaticFiles/src/StaticFileMiddleware.cs
            app.UseStaticFiles();

            // Identity
            app.UseAuthentication();


            // Configurando MVC
            app.UseMvc();
                        

            // Configurando Swagger
            app.AddMySwagger(mySettings.Swagger);


            return app;
        }

    }
}
