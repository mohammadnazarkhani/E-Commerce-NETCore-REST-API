using System.Linq.Expressions;
using Domain.Entities.Base;

namespace Application.Interfaces.Repositories;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    // Get methods with includes
    Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
    Task<IReadOnlyList<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
    
    // Find methods with criteria and includes
    Task<TEntity?> FindAsync(
        Expression<Func<TEntity, bool>> criteria, 
        params Expression<Func<TEntity, object>>[] includes);
    Task<IReadOnlyList<TEntity>> FindAllAsync(
        Expression<Func<TEntity, bool>> criteria, 
        params Expression<Func<TEntity, object>>[] includes);

    // Query with ordering
    Task<IReadOnlyList<TEntity>> FindAllAsync(
        Expression<Func<TEntity, bool>> criteria,
        Expression<Func<TEntity, object>> orderBy,
        bool ascending = true,
        params Expression<Func<TEntity, object>>[] includes);

    // Pagination support
    Task<(IReadOnlyList<TEntity> Items, int TotalCount)> FindAllAsync(
        Expression<Func<TEntity, bool>> criteria,
        int skip,
        int take,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool ascending = true,
        params Expression<Func<TEntity, object>>[] includes);
    
    // Add methods
    Task<TEntity> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
    
    // Update methods
    Task UpdateAsync(TEntity entity);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    
    // Delete methods
    Task DeleteAsync(TEntity entity);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    
    // Additional query methods
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> criteria);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria);
}
