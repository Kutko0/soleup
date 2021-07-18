using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Soleup.API.DTOs;

namespace Soleup.API.Auth
{

    // TODO: use this for rest of dev https://weblog.west-wind.com/posts/2021/Mar/09/Role-based-JWT-Tokens-in-ASPNET-Core
    public class TokenService : ITokenService
    { 
        private const double EXPIRY_DURATION_MINUTES = 180;
        private string KEY_SECRET;
        private string ISSUER;
        private readonly IConfiguration config;

        // Getting data from appsettings but it shoudl be done from env variables later
        public TokenService(IConfiguration config)
        {
            this.config = config;
            this.ISSUER = config["Jwt:Issuer"];
            this.KEY_SECRET = config["Jwt:Key"];
        }

        // Build a token and return it's value as a string
        public string BuildToken(UserDTO user)
        {
            var FullName = user.First_Name + " " + user.Last_Name;

            var claims = new[] {    
                new Claim(ClaimTypes.Name, FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY_SECRET));        
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);           
            var tokenDescriptor = new JwtSecurityToken(ISSUER, ISSUER, claims, 
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);        
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);  
        }

        // Checks the token validity and return true if it's valid
        public bool IsTokenValid(string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(KEY_SECRET);           
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler(); 
            try 
            {
                tokenHandler.ValidateToken(token, 
                new TokenValidationParameters   
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true, 
                    ValidateAudience = true,    
                    ValidIssuer = ISSUER,
                    ValidAudience = ISSUER, 
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);            
            }
            catch
            {
                return false;
            }
            return true;    
        }

    }
}