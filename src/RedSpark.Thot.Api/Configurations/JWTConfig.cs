using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RedSpark.Thot.Api.Infra.CrossCutting.Settings;
using System.Text;

namespace RedSpark.Thot.Api.Configurations
{
    public static class JWTConfig
    {
        public static IServiceCollection AddJWTConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Toda autenticação é baseada em Token
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  // Deve validar o Token
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true; // Exige que quem quiser se autenticar precisa vir de uma url com https
                x.SaveToken = true; // Token deve ser guardado no AuthenticationProperties após uma autenticação com sucesso.
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, // Validar no Token quem emitiu o token e a chave
                    IssuerSigningKey = new SymmetricSecurityKey(key), // Informando a chave de validação
                    ValidateIssuer = true, // Validar o Issuer conforme o nome.
                    ValidateAudience = true, // Validar a onde esse token é valido
                    ValidAudience = appSettings.ValidIn, // Informando a Audience(Url da minha aplicação)
                    ValidIssuer = appSettings.From // Informando o Issuer(nome da minha aplicação)
                };
            });

            return services;
        }
    }
}
