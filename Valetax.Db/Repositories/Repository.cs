using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Valetax.Db.Context;
using Valetax.Db.Entities;
using Valetax.Db.Repositories.Interfaces;

namespace Valetax.Db.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected AppDbContext DbContext { get; }

    public Repository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual async Task Delete(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default)
    {
        var entity = DbContext.Set<TEntity>().SingleOrDefault(expression);

        if (entity != null)
        {
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync(ct);
        }
    }

    public virtual async Task Delete(TEntity entityToRemove, CancellationToken ct = default)
    {
        DbContext.Set<TEntity>().Remove(entityToRemove);
        await DbContext.SaveChangesAsync(ct);
    }

    public virtual async Task Delete(TEntity[] entitiesToRemove, CancellationToken ct = default)
    {
        DbContext.Set<TEntity>().RemoveRange(entitiesToRemove);
        await DbContext.SaveChangesAsync(ct);
    }

    public virtual async Task<TEntity> InsertAsync(TEntity newEntity, CancellationToken ct = default)
    {
        var entity = await DbContext.Set<TEntity>().AddAsync(newEntity, ct);
        await DbContext.SaveChangesAsync(ct);

        return entity.Entity;
    }

    public virtual async Task InsertAsync(TEntity[] newEntity, CancellationToken ct = default)
    {
        await DbContext.Set<TEntity>().AddRangeAsync(newEntity, ct);
        await DbContext.SaveChangesAsync(ct);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entityToUpdate, CancellationToken ct = default)
    {
        var entity = DbContext.Set<TEntity>().Update(entityToUpdate);
        await DbContext.SaveChangesAsync(ct);

        return entity.Entity;
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression,
        CancellationToken ct = default)
    {
        return await DbContext.Set<TEntity>().FirstOrDefaultAsync(expression, ct);
    }

    public virtual async Task<TEntity?> GetAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await DbContext.Set<TEntity>().FindAsync(id);
        return entity;
    }

    public virtual async Task<TEntity?> GetAsTrackingAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await DbContext.Set<TEntity>()
            .AsTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);

        return entity;
    }

    public Task<int> SaveAsync(CancellationToken ct = default)
    {
        return DbContext.SaveChangesAsync(ct);
    }
}