using Microsoft.Extensions.DependencyInjection;
using RedSpark.Thot.Api.Domain.Models.Example;
using System.Collections.Generic;
using RedSpark.Thot.Api.Domain.Interfaces;
using RedSpark.Thot.Api.Data.Repository;
using RedSpark.Thot.Api.Models.Lead.Output;
using RedSpark.Thot.Api.Infra.CrossCutting.Helpers;

namespace RedSpark.Thot.Api.Infra.IoC
{
    public static class NativeIoC
    {

        public static IServiceCollection Resolve(this IServiceCollection services)
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

            services.AddSingleton<ICollection<LeadSummary>, List<LeadSummary>>(s =>
            {
                return DataGenerator.LeadSummaries(10);
            });

            services.AddScoped<ILeadRepository, LeadCollectionRepository>();

            return services;
        }
    }
}
