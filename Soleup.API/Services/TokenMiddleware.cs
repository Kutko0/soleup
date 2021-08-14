using System.Text;  
using Microsoft.IdentityModel.Tokens;  
using Microsoft.Extensions.Configuration;  
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.AspNetCore.Authentication.JwtBearer;  

namespace Soleup.API.Services
{
    public static class AuthenticationExtension  
    {  
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)  
        {  
            var secret = config.GetSection("AuthTokenConfig").GetSection("SECRET").Value;  
  
            var key = Encoding.ASCII.GetBytes(secret);  
            services.AddAuthentication(x =>  
            {  
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
            })  
            .AddJwtBearer(x =>  
            {  
                x.TokenValidationParameters = new TokenValidationParameters  
                {  
                    IssuerSigningKey = new SymmetricSecurityKey(key),  
                    ValidateIssuer = true,  
                    ValidateAudience = true,  
                    ValidIssuer = "localhost",  
                    ValidAudience = "localhost"  
                };  
                // TODO: Make a env file to distinguish development and production
            });  
  
            return services;  
        }  
    }  
}