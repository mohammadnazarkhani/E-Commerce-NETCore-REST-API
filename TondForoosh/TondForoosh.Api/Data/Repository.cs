using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TondForoosh.Api.Data;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _dbSet = unitOfWork.Set<TEntity>();
    }

    public int Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<int>> AddAsync(List<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public int Update(TEntity entityToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(TEntity entityToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateRangeAsync(List<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task<List<int>> UpdateAsync(List<TEntity> entitiesToUpdate)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public TEntity? GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetByIdAsync(object id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(int page, int take)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TResult>> GetAllSelect<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TReturn> GetAllPaged<TResult, TKey, TGroup, TReturn>(List<Expression<Func<TEntity, bool>>> predicates, Expression<Func<TEntity, TResult>> firstSelector, Expression<Func<TResult, TKey>> orderSelector, Func<TResult, TGroup> groupSelector, Func<IGrouping<TGroup, TResult>, TReturn> selector)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TReturn> GetAllPaged<TResult, TGroup, TReturn>(Expression<Func<TEntity, TResult>> firstSelector, Func<TResult, TGroup> groupSelector, Func<IGrouping<TGroup, TResult>, TReturn> selector)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TResult>> GetAllAsync<TResult, TProperty>(Expression<Func<TEntity, int, TResult>> selector, Expression<Func<TEntity, TProperty>> include, int page, int take)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, int page, int take)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, int page, int take)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProperty>> include)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate, int page, int take)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync<TOrderKey>(Expression<Func<TEntity, TOrderKey>> orderBy, Expression<Func<TEntity, bool>> predicate, int page, int take)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync<TOrderKey, TInclude>(Expression<Func<TEntity, TOrderKey>> orderBy, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TInclude>> include, int page, int take)
    {
        throw new NotImplementedException();
    }

    public Task<QueryResult<TEntity>> GetAllAsync(QueryObjectParams queryObjectParams)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> LastOrDefaultAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TResult>> GetAllSelect<TResult>(Expression<Func<TEntity, TResult>> selector)
    {
        throw new NotImplementedException();
    }

    public Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams)
    {
        throw new NotImplementedException();
    }

    public Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<QueryResult<TEntity>> GetOrderedPageQueryResultAsync(QueryObjectParams queryObjectParams, IQueryable<TEntity> query)
    {
        throw new NotImplementedException();
    }

    public Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, List<Expression<Func<TEntity, object>>> includes)
    {
        throw new NotImplementedException();
    }

    public Task<QueryResult<TEntity>> GetPageAsync<TProperty>(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, TProperty>>> includes = null)
    {
        throw new NotImplementedException();
    }

    private readonly
}