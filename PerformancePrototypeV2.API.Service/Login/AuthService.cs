using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PerformancePrototypeV2.API.Service.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePrototypeV2.API.Service.Login
{
    public class AuthService :IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Authenticate(LoginDTO loginModel)
        {
            // 1. validate the user's credentials against a database here -- Pending
            // 2. Include Hashing logic

            // hardcoded check.
            if (loginModel.Email == "user@example.com" && loginModel.Password == "password")
            {
                
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Email, loginModel.Email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            return null;
        }
    }
}
