using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Domain
{
    public class JwtHelper
    {
        public static JwtSecurityToken GetJwtToken(
            int userId,
            string signingKey,
            string issuer,
            string audience,
            DateTime expiration,
            Claim[] additionalClaims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: expiration,
                claims: additionalClaims,
                signingCredentials: creds
            );
        }
    }
}