using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TBMMORPG.Auth.Services.Interface;

namespace TBMMORPG.Auth.Services
{
    public class JWTService : IJWTService
    {
        public string GenerateJSONWebToken(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim("UserName", userName),
            };

            var now = DateTime.UtcNow;
            
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
