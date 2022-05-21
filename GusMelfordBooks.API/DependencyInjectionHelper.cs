using GusMelfordBooks.Domain.Interfaces;
using GusMelfordBooks.Domain.Settings;
using GusMelfordBooks.Extensions;
using GusMelfordBooks.Infrastructure;
using GusMelfordBooks.Infrastructure.Interfaces;
using GusMelfordBooks.Repositories;
using GusMelfordBooks.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GusMelfordBooks.API;

public static class DependencyInjectionHelper
{
    public static void AddServices(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddSingleton(appSettings);
        services.AddTransient<IDatabaseContext>(_ => new DatabaseContext(appSettings.DatabaseSettings));
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IAuthRepository, AuthRepository>();

        services.AddHealthChecks();
        services.AddControllers();
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = appSettings.AuthOptions?.Issuer,
                    ValidateAudience = true,
                    ValidAudience = appSettings.AuthOptions?.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = Helper.GetSymmetricSecurityKey(appSettings.AuthOptions?.Key),
                    ValidateIssuerSigningKey = true,
                };
            });
    }
}