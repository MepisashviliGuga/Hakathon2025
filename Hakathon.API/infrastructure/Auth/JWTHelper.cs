using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Hakathon.Domain;


namespace Hakathon.API.infrastructure.Auth
{
    public static class JWTHelper
    {
        public static string GenerateSecurityToken(int id, IOptions<JWTConfiguration> options)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(options.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {                    
                    new Claim(ClaimTypes.NameIdentifier,id.ToString())                    
                }),

                Expires = DateTime.UtcNow.AddMinutes(options.Value.ExpirationInMInutes),
                Audience = "localhost",
                Issuer = "localhost",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
