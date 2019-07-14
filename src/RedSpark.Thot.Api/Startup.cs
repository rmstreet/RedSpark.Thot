using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RedSpark.Thot.Api.Models;
using static RedSpark.Thot.Api.Controllers.ProductsController;

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

            // Uma instancia por chamada
            // services.AddTransient<ICollection<Product>, List<Product>>();

            // Uma instancia por Request
            //services.AddScoped<ICollection<Product>, List<Product>>();

            // Uma instancia por aplicação
            services.AddSingleton<ICollection<Product>, List<Product>>(s =>
            {
                return new List<Product>()
                {
                    new Product() {Id = 1, Name = "Tênis Addidas"},
                    new Product() {Id = 2, Name = "Tênis Nike"},
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
