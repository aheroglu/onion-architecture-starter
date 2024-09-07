using Server.Domain.Entities;

namespace Server.Application.Services;

public interface IJwtService
{
    string GenerateToken(AppUser user);
}
