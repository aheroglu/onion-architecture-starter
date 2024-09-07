using Microsoft.AspNetCore.Identity;

namespace Server.Domain.Entities;

public sealed class AppUser : IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }
}
