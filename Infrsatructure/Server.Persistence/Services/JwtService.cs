using Microsoft.IdentityModel.Tokens;
using Server.Application.Services;
using Server.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server.Persistence.Services;

public sealed class JwtService : IJwtService
{
    public string GenerateToken(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
        };

        DateTime notBefore = DateTime.Now;
        DateTime expires = DateTime.Now.AddDays(15);

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(string.Join('-', Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid())));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken securityToken = new(
            issuer: "Server",
            audience: "Client",
            claims,
            notBefore,
            expires,
            signingCredentials);

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(securityToken);

        return token;
    }
}