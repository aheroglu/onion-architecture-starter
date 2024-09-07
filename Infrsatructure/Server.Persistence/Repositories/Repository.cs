using Microsoft.EntityFrameworkCore;
using Server.Application.Repositories;
using Server.Persistence.Context;
using System.Linq.Expressions;

namespace Server.Persistence.Repositories;

public sealed class Repository<T>(
    AppDbContext context) : IRepository<T> where T : class
{
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default)
    {
        await context.Set<T>().AddRangeAsync(entities, cancellationToken);
    }

    public bool Any(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().Any(expression);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().AnyAsync(expression, cancellationToken);
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public async Task DeleteByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        T entity = await context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken) ?? default!;
        context.Set<T>().Remove(entity);
    }

    public async Task DeleteByIdAsync(string id)
    {
        T entity = await context.Set<T>().FindAsync(id) ?? default!;
        context.Set<T>().Remove(entity);
    }

    public void DeleteRange(ICollection<T> entities)
    {
        context.Set<T>().RemoveRange(entities);
    }

    public IQueryable<T> GetAll()
    {
        return context.Set<T>().AsNoTracking().AsQueryable();
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default, bool isTrackingActive = false)
    {
        if (isTrackingActive)
        {
            return await context.Set<T>().ToListAsync(cancellationToken);
        }
        else
        {
            return await context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }
    }

    public IQueryable<T> GetAllWithTracking()
    {
        return context.Set<T>().AsQueryable();
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, bool isTrackingActive = true)
    {
        T entity;
        if (isTrackingActive)
        {
            entity = await context.Set<T>().Where(expression).FirstOrDefaultAsync(cancellationToken) ?? default!;
        }
        else
        {
            entity = await context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken) ?? default!;
        }
        return entity;
    }

    public T GetByExpression(Expression<Func<T, bool>> expression)
    {
        T entity = context.Set<T>().Where(expression).AsNoTracking().FirstOrDefault() ?? default!;
        return entity;
    }

    public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        T entity = await context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken) ?? default!;
        return entity;
    }

    public T GetByExpressionWithTracking(Expression<Func<T, bool>> expression)
    {
        T entity = context.Set<T>().Where(expression).FirstOrDefault() ?? default!;
        return entity;
    }

    public async Task<T> GetByExpressionWithTrackingAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        T entity = await context.Set<T>().Where(expression).FirstOrDefaultAsync(cancellationToken) ?? default!;
        return entity;
    }

    public T GetFirst()
    {
        T entity = context.Set<T>().AsNoTracking().FirstOrDefault() ?? default!;
        return entity;
    }

    public async Task<T> GetFirstAsync(CancellationToken cancellationToken = default)
    {
        T entity = await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(cancellationToken) ?? default!;
        return entity;
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().AsNoTracking().Where(expression).AsQueryable();
    }

    public IQueryable<T> WhereWithTracking(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().Where(expression).AsQueryable();
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }

    public void UpdateRange(ICollection<T> entities)
    {
        context.Set<T>().UpdateRange(entities);
    }
}
