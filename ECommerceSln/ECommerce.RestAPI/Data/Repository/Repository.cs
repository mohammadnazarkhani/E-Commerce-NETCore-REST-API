using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Repository;

/// <summary>
/// Generic repository implementation with EF Core
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<TEntity>();
    }

    #region Query Operations

    public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id, string[] includeProperties, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string[] includeProperties, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, string[] includeProperties, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.Where(predicate).ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.SingleOrDefaultAsync(predicate, cancellationToken);
    }

    #endregion

    #region Pagination and Ordering

    public virtual async Task<(IEnumerable<TEntity> Data, int TotalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string[]? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (predicate != null)
            query = query.Where(predicate);

        if (includeProperties != null)
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
        }

        var totalCount = await query.CountAsync(cancellationToken);

        if (orderBy != null)
            query = orderBy(query);

        var data = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (data, totalCount);
    }

    #endregion

    #region Aggregation Operations

    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.CountAsync(cancellationToken);
    }

    public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.CountAsync(predicate, cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public virtual async Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AllAsync(predicate, cancellationToken);
    }

    #endregion

    #region Command Operations

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var entry = await _dbSet.AddAsync(entity, cancellationToken);
        return entry.Entity;
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        await _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public virtual Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        _dbSet.UpdateRange(entities);
        return Task.CompletedTask;
    }

    public virtual Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public virtual async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public virtual Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        _dbSet.RemoveRange(entities);
        return Task.CompletedTask;
    }

    public virtual async Task<int> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var entities = await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        if (entities.Any())
        {
            _dbSet.RemoveRange(entities);
        }
        return entities.Count;
    }

    #endregion

    #region Advanced Operations

    public virtual async Task<IEnumerable<TEntity>> ExecuteQueryAsync(string sql, object[] parameters, CancellationToken cancellationToken)
    {
        return await _dbSet.FromSqlRaw(sql, parameters).ToListAsync(cancellationToken);
    }

    public virtual async Task<int> ExecuteComandAsync(string sql, object[] parameters, CancellationToken cancellationToken = default)
    {
        return await _context.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
    }

    public virtual async Task ReloadAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _context.Entry(entity).ReloadAsync(cancellationToken);
    }

    public virtual void Detach(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _context.Entry(entity).State = EntityState.Detached;
    }

    public virtual void Attach(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _dbSet.Attach(entity);
    }

    #endregion

    #region Unit of Work Pattern Support

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    #endregion

    #region Query Building

    public virtual IQueryable<TEntity> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public virtual IQueryable<TEntity> AsNoTracking()
    {
        return _dbSet.AsNoTracking();
    }

    #endregion
}