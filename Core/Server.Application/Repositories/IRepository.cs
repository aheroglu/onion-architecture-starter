using System.Linq.Expressions;

namespace Server.Application.Repositories;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAllWithTracking();
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default, bool isTrackingActive = false);
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    IQueryable<T> WhereWithTracking(Expression<Func<T, bool>> expression);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, bool isTrackingActive = true);
    Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T> GetByExpressionWithTrackingAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T> GetFirstAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    bool Any(Expression<Func<T, bool>> expression);
    T GetByExpression(Expression<Func<T, bool>> expression);
    T GetByExpressionWithTracking(Expression<Func<T, bool>> expression);
    T GetFirst();
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Add(T entity);
    Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default);
    void Update(T entity);
    void UpdateRange(ICollection<T> entities);
    Task DeleteByIdAsync(string id);
    Task DeleteByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    void Delete(T entity);
    void DeleteRange(ICollection<T> entities);
}
