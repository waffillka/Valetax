using System.Linq.Expressions;
using Valetax.Db.Entities;

namespace Valetax.Db.Repositories.Interfaces;

public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    Task Delete(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default);
    Task Delete(TEntity entityToRemove, CancellationToken ct = default);
    Task Delete(TEntity[] entitiesToRemove, CancellationToken ct = default);
    Task<TEntity?> GetAsync(Guid id, CancellationToken ct = default);
    Task<TEntity> InsertAsync(TEntity newEntity, CancellationToken ct = default);
    Task InsertAsync(TEntity[] newEntity, CancellationToken ct = default);
    Task<TEntity> UpdateAsync(TEntity entityToUpdate, CancellationToken ct = default);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default);
    Task<int> SaveAsync(CancellationToken ct = default);
    Task<TEntity?> GetAsTrackingAsync(Guid id, CancellationToken ct = default);
}