using System;
using System.Linq.Expressions;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Specifications;

/// <summary>
/// Fluent specification builder for creating complex specifications.
/// This class provides methods to build specifications for querying entities.
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public class SpecificationBuilder<TEntity> where TEntity : class, IEntity
{
    private readonly List<Expression<Func<TEntity, bool>>> _criteria = new();
    private readonly List<Expression<Func<TEntity, object>>> _includes = new();
    private readonly List<string> _includeStrings = new();
    private readonly List<Expression<Func<TEntity, object>>> _orderBy = new();
    private readonly List<Expression<Func<TEntity, object>>> _orderByDescending = new();
    private int? _take;
    private int? _skip;
    private bool _asNoTracking;
    private bool _asSplitQuery;
    private Expression<Func<TEntity, object>>? _groupBy;

    /// <summary>
    /// Adds a where clause to the specification.
    /// </summary>
    /// <param name="criteria">Filter criteria</param>
    /// <returns>Current builder instance</returns>
    public SpecificationBuilder<TEntity> Where(Expression<Func<TEntity, bool>> criteria)
    {
        _criteria.Add(criteria);
        return this;
    }

    /// <summary>
    /// Adds an include expression for eager loading related entities.
    /// </summary>
    /// <param name="includeExpression">Include expression</param>
    /// <returns>Current builder instance</returns>
    public SpecificationBuilder<TEntity> Include(Expression<Func<TEntity, object>> includeExpression)
    {
        _includes.Add(includeExpression);
        return this;
    }

    /// <summary>
    /// Adds an include string for eager loading related entities.
    /// </summary>
    /// <param name="includeString">Include string</param>
    /// <returns>Current builder instance</returns>
    public SpecificationBuilder<TEntity> Include(string includeString)
    {
        _includeStrings.Add(includeString);
        return this;
    }

    /// <summary>
    /// Adds an order by expression to the specification.
    /// </summary>
    /// <param name="orderByExpression">Order by expression</param>
    /// <returns>Current builder instance</returns>
    public SpecificationBuilder<TEntity> OrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        _orderBy.Add(orderByExpression);
        return this;
    }

    /// <summary>
    /// Adds an order by descending expression to the specification.
    /// </summary>
    /// <param name="orderByDescExpression">Order by descending expression</param>
    /// <returns>Current builder instance</returns>
    public SpecificationBuilder<TEntity> OrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
    {
        _orderByDescending.Add(orderByDescExpression);
        return this;
    }

    /// <summary>
    /// Applies pagin to the specification.
    /// </summary>
    /// <param name="skip">Number of items to skip</param>
    /// <param name="take">Number of items to take</param>
    /// <returns>Current builder instance</returns>
    public SpecificationBuilder<TEntity> Paging(int skip, int take)
    {
        _skip = skip;
        _take = take;
        return this;
    }

    /// <summary>
    /// Disables change tracking for the specification.
    /// This method allows the query to be executed without tracking changes to the entities.
    /// </summary>
    /// <returns>Current builder instance</returns>
    public SpecificationBuilder<TEntity> AsNoTracking()
    {
        _asNoTracking = true;
        return this;
    }

    /// <summary>
    /// Enables split query for the specification.
    /// </summary>
    /// <returns>Current builder instance</returns>
    public SpecificationBuilder<TEntity> AsSplitQuery()
    {
        _asSplitQuery = true;
        return this;
    }

    /// <summary>
    /// Adds a group by expression to the specification.
    /// This method allows grouping entities by a specified property.
    /// </summary>
    /// <param name="groupByExpression">Group by expression</param>
    /// <returns>Current builder instance</returns>
    public SpecificationBuilder<TEntity> GroupBy(Expression<Func<TEntity, object>> groupByExpression)
    {
        _groupBy = groupByExpression;
        return this;
    }

    /// <summary>
    /// Builds the specification
    /// </summary>
    /// <returns>Built specification</returns>
    public ISpecification<TEntity> Build()
    {
        return new BuiltSpecification<TEntity>(
            _criteria,
            _includes,
            _includeStrings,
            _orderBy,
            _orderByDescending,
            _take,
            _skip,
            _asNoTracking,
            _asSplitQuery,
            _groupBy
        );
    }
}
