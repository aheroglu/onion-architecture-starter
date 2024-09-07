using Server.Application.Repositories;
using Server.Persistence.Context;

namespace Server.Persistence.Repositories;

public sealed class UnitOfWork(
    AppDbContext context) : IUnitOfWork
{
    public int SaveChanges()
    {
        return context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}
