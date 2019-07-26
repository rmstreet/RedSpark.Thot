using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RedSpark.Thot.Api.Application.AutoMapper;
using System;

namespace RedSpark.Thot.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

//#pragma warning disable CS0618 // Type or member is obsolete
//            //services.AddAutoMapper();
//#pragma warning restore CS0618 // Type or member is obsolete

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project

            var config = AutoMapperSetup.RegisterMappings();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
