using System;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Specifications;

/// <summary>
/// Base specification class providing common functionality
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public class BaseSpecification<TEntity> : IReadSpecification<TEntity> where TEntity : class, IEntity
{
    public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = new();
    public List<string> IncludeStrings { get; } = new();
    public List<Expression<Func<TEntity, object>>> OrderBy { get; } = new();
    public List<Expression<Func<TEntity, object>>> OrderByDescending { get; } = new();
    public int? Take { get; private set; }
    public int? Skip { get; private set; }
    public bool AsNoTracking { get; private set; }
    public bool AsSplitQuery { get; private set; }
    public Expression<Func<TEntity, object>>? GroupBy { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseSpecification{TEntity}"/> class.
    /// Allows setting criteria for filtering entities.
    /// </summary>
    /// <param name="criteria">Filter criteria</param>
    protected BaseSpecification(Expression<Func<TEntity, bool>>? criteria = null)
    {
        Criteria = criteria;
    }

    /// <summary>
    /// Adds include expression for eager loading related entities.
    /// This method allows specifying related entities to include in the query results.
    /// </summary>
    /// <param name="includeExpression">Include expression</param>
    /// <returns>Current specification instance</returns>
    protected virtual BaseSpecification<TEntity> AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        Includes.Add(includeExpression);
        return this;
    }

    /// <summary>
    /// Adds include string for eager loading related entities.
    /// This method allows specifying related entities to include in the query results using a string path.
    /// </summary>
    /// <param name="includeString">Include string</param>
    /// <returns>Current specification instance</returns>
    protected virtual BaseSpecification<TEntity> AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
        return this;
    }

    /// <summary>
    /// Adds order by expression for sorting entities.
    /// This method allows specifying the property to sort by in ascending order.
    /// </summary>
    /// <param name="orderByExpression">Order by expression</param>
    /// <returns>Current specification instance</returns>
    protected virtual BaseSpecification<TEntity> AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        OrderBy.Add(orderByExpression);
        return this;
    }

    /// <summary>
    /// Adds order by descending expression for sorting entities.
    /// This method allows specifying the property to sort by in descending order.
    /// </summary>
    /// <param name="orderByDescExpression">Order by descending expression</param>
    /// <returns>Current specification instance</returns>
    protected virtual BaseSpecification<TEntity> AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
    {
        OrderByDescending.Add(orderByDescExpression);
        return this;
    }

    /// <summary>
    /// Applies pagin to the specification.
    /// This method allows specifying the number of records to skip and take for pagination.
    /// </summary>
    /// <param name="skip">Number of items to skip</param>
    /// <param name="take">Number of items to take</param>
    /// <returns>Currrent specification instance</returns>
    protected virtual BaseSpecification<TEntity> ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        return this;
    }

    /// <summary>
    /// Disables change tracking for the query.
    /// This method allows the query to be executed without tracking changes to the entities.
    /// </summary>
    /// <returns>Current specification instance</returns>
    protected virtual BaseSpecification<TEntity> ApplyNoTracking()
    {
        AsNoTracking = true;
        return this;
    }

    /// <summary>
    /// Enables split queries for the query.
    /// </summary>
    /// <returns>Current specification instance</returns>
    protected virtual BaseSpecification<TEntity> ApplySplitQuery()
    {
        AsSplitQuery = true;
        return this;
    }

    /// <summary>
    /// Adds group by expression for grouping entities.
    /// </summary>
    /// <param name="groupByExpression">Group by expression</param>
    /// <returns>Current specification instance</returns>
    protected virtual BaseSpecification<TEntity> ApplyGroupBy(Expression<Func<TEntity, object>> groupByExpression)
    {
        GroupBy = groupByExpression;
        return this;
    }

    /// <summary>
    /// Evalates the specification criteria against a given entity.
    /// This method checks if the entity satisfies the criteria defined in the specification.
    /// </summary>
    /// <param name="entity">Entity to evaluate</param>
    /// <returns>True if entity stisfies the specification</returns>
    public virtual bool IsStatisfiedBy(TEntity entity)
    {
        if (Criteria == null)
            return true;

        return Criteria.Compile()(entity);
    }
}
