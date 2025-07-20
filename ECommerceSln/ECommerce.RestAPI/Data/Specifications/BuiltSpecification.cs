using System;
using System.Linq.Expressions;
using ECommerce.RestAPI.Data.Extensions;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Specifications;

/// <summary>
/// Built specification from the builder.
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
internal class BuiltSpecification<TEntity> : ISpecification<TEntity> where TEntity : class, IEntity
{
    public Expression<Func<TEntity, bool>>? Criteria { get; }

    public List<Expression<Func<TEntity, object>>> Includes { get; }

    public List<string> IncludeStrings { get; }

    public List<Expression<Func<TEntity, object>>> OrderBy { get; }

    public List<Expression<Func<TEntity, object>>> OrderByDescending { get; }

    public int? Take { get; }

    public int? Skip { get; }

    public bool AsNoTracking { get; }

    public bool AsSplitQuery { get; }

    public Expression<Func<TEntity, object>>? GroupBy { get; }

    public BuiltSpecification(
        List<Expression<Func<TEntity, bool>>> criteria,
        List<Expression<Func<TEntity, object>>> includes,
        List<string> includeStrings,
        List<Expression<Func<TEntity, object>>> orderBy,
        List<Expression<Func<TEntity, object>>> orderByDescending,
        int? take,
        int? skip,
        bool asNoTracking,
        bool asSplitQuery,
        Expression<Func<TEntity, object>>? groupBy)
    {
        Criteria = CombineCriteria(criteria);
        Includes = includes;
        IncludeStrings = includeStrings;
        OrderBy = orderBy;
        OrderByDescending = orderByDescending;
        Take = take;
        Skip = skip;
        AsNoTracking = asNoTracking;
        AsSplitQuery = asSplitQuery;
        GroupBy = groupBy;
    }

   private Expression<Func<TEntity, bool>>? CombineCriteria(List<Expression<Func<TEntity, bool>>> criteria)
    {
        if (!criteria.Any())
            return null;

        var combined = criteria.First();
        foreach (var criterion in criteria.Skip(1))
        {
            combined = combined.And(criterion);
        }

        return combined;
    }
}
