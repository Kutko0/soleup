using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Soleup.API.Services
{
    public class AuthTokenService
    {
        private readonly string _secret;  
        private readonly string _expDate;  
  
        public AuthTokenService(IConfiguration config)  
        {  
            _secret = config.GetSection("AuthTokenConfig").GetSection("SECRET").Value;  
            _expDate = config.GetSection("AuthTokenConfig").GetSection("EXPIRES_IN_HOUR").Value;  
        }  
  
        public string GenerateSecurityToken(string email)  
        {  
            var tokenHandler = new JwtSecurityTokenHandler();  
            var key = Encoding.ASCII.GetBytes(_secret);  
            var tokenDescriptor = new SecurityTokenDescriptor  
            {  
                Subject = new ClaimsIdentity(new[]  
                {  
                    new Claim(ClaimTypes.Email, email)  
                }),  
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),  
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)  
            };  
  
            var token = tokenHandler.CreateToken(tokenDescriptor);  
  
            return tokenHandler.WriteToken(token);  
  
        }  
    }
}