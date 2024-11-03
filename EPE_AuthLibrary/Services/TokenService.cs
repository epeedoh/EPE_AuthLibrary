using EPE_AuthLibrary.Config;
using EPE_AuthLibrary.Interfaces;
using EPE_AuthLibrary.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtConfig _jwtConfig;

        public TokenService(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
               new Claim(ClaimTypes.Name, user.Username),
               new Claim(ClaimTypes.Role, user.Role)
           };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: _jwtConfig.Issuer,
              audience: _jwtConfig.Audience,
              claims: claims,
              expires: DateTime.Now.AddMinutes(_jwtConfig.ExpirationMinutes),
              signingCredentials: creds
          );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
