using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GusMelfordBooks.Infrastructure.Interfaces;

public interface IDatabaseContext
{
    void Update<TEntity>(TEntity entity);
    
    ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, 
        CancellationToken cancellationToken = new CancellationToken()) where TEntity : class;
    
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
    
    Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);
    
    void UpdateRange(IEnumerable<object> entities);
}