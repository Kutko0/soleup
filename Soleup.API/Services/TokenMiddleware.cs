using System.Text;  
using Microsoft.IdentityModel.Tokens;  
using Microsoft.Extensions.Configuration;  
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.AspNetCore.Authentication.JwtBearer;
using dotenv.net;

namespace Soleup.API.Services
{
    public static class AuthenticationExtension  
    {  
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)  
        {  
            string secret = DotEnv.Read()["TOKEN_SECRET"];  
            byte[] key = Encoding.ASCII.GetBytes(secret);  
            string _issuer = DotEnv.Read()["ISSUER_LOCAL"];
    	    string _audience = DotEnv.Read()["ISSUER_LOCAL"];
  
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
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,  
                    ValidateAudience = true,  
                    ValidIssuer = "localhost",  
                    ValidAudience = "localhost"  
                };  
            });  
  
            return services;  
        }  
    }  
}