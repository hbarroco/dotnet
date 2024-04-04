using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using school_route.infrastructure.JwtToken;
using school_route.infrastructure.Log;

namespace school_route.infrastructure
{
    public static class InfraIoCRegistration
    {
        public static void AddServiceInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters =
                    TokenHelper.GetTokenValidationParameters(builder.Configuration);
            });

            builder.Services.AddSingleton<ITokenHelper, TokenHelper>();
            builder.Services.AddSingleton<ILoggerHelper, LoggerHelper>();
        }
    }
}
