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

    public SpecificationBuilder<TEntity> Where(Expression<Func<TEntity, bool>> criteria)
    {
        _criteria.Add(criteria);
        return this;
    }

    public SpecificationBuilder<TEntity> Include(Expression<Func<TEntity, object>> includeExpression)
    {
        _includes.Add(includeExpression);
        return this;
    }

    public SpecificationBuilder<TEntity> Include(string includeString)
    {
        _includeStrings.Add(includeString);
        return this;
    }

    public SpecificationBuilder<TEntity> OrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        _orderBy.Add(orderByExpression);
        return this;
    }

    public SpecificationBuilder<TEntity> OrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
    {
        _orderByDescending.Add(orderByDescExpression);
        return this;
    }

    public SpecificationBuilder<TEntity> Paging(int skip, int take)
    {
        _skip = skip;
        _take = take;
        return this;
    }

    public SpecificationBuilder<TEntity> AsNoTracking()
    {
        _asNoTracking = true;
        return this;
    }

    public SpecificationBuilder<TEntity> AsSplitQuery()
    {
        _asSplitQuery = true;
        return this;
    }

    public SpecificationBuilder<TEntity> GroupBy(Expression<Func<TEntity, object>> groupByExpression)
    {
        _groupBy = groupByExpression;
        return this;
    }

    public ISpecification<TEntity> Build()
    {
        return new BuiltSpecificcation<TEntity>(
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
