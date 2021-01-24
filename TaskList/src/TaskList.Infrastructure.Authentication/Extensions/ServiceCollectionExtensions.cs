using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TaskList.Infrastructure.Authentication.Interfaces;
using TaskList.Infrastructure.Authentication.Services;

namespace TaskList.Infrastructure.Authentication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public const string AuthenticationSecret = "AuthenticationSecret";

        public static IServiceCollection AddAuthenticationProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>(AuthenticationSecret));
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddScoped<ITokenService, TokenService>();
            
            return services;
        }
    }
}