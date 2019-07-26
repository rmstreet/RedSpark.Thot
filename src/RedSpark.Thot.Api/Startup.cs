using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Converters;
using RedSpark.Thot.Api.Configurations;
using RedSpark.Thot.Api.Infra.CrossCutting.Settings;
using System;

namespace RedSpark.Thot.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddWebApi(Configuration,
                options =>
                {
                    options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                });

            services.Configure<MySettings>(Configuration.GetSection("MySettings"));


            var mySettings = Configuration
                .GetSection("MySettings")
                .Get<MySettings>();

            // Config Swagger
            services.AddMySwagger(mySettings.Swagger);

            services.AddAutoMapperSetup();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<MySettings> settings)
        {
            app.AddMyConfigApp(env, settings?.Value ?? throw new Exception("Sem Map de Settings"));
        }
    }
}
