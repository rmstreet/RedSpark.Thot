using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RedSpark.Thot.Api.Infra.CrossCutting.Settings;
using Swashbuckle.AspNetCore.Swagger;

namespace RedSpark.Thot.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddMySwagger(this IServiceCollection services, SwaggerSettings settings)
        {
            return services
                .AddSwaggerGen(s =>
                {
                    var versions = settings.Versions;
                    versions.ForEach(info =>
                    {
                        s.SwaggerDoc(info.Version, new Info { Version = info.Version, Title = info.Title, Description = info.Description });
                    });
                });
        }

        public static IApplicationBuilder AddMySwagger(this IApplicationBuilder app, SwaggerSettings settings)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            var versions = settings.Versions;
            app.UseSwaggerUI((c =>
            {
                versions.ForEach(info =>
                {
                    c.SwaggerEndpoint($"{info.Url}", $"{info.Title} - {info.Version}");
                });
            }));

            return app;
        }
    }
}
