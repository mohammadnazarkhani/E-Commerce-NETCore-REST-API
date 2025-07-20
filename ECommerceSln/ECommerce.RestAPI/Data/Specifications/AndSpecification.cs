using System;
using ECommerce.RestAPI.Data.Extensions;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Specifications;

/// <summary>
/// And specification that combines multiple specifications.
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public class AndSpecification<TEntity> : BaseSpecification<TEntity>
    where TEntity : class, IEntity
{
    public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        : base(left.Criteria != null && right.Criteria != null
            ? left.Criteria.And(right.Criteria)
            : left.Criteria ?? right.Criteria)
    {
        // Combine includes
        foreach (var include in left.Includes.Concat(right.Includes))
            AddInclude(include);

        foreach (var include in left.IncludeStrings.Concat(right.IncludeStrings))
            AddInclude(include);

        // Combine order by
        foreach (var orderBy in left.OrderBy.Concat(right.OrderBy))
            AddOrderBy(orderBy);

        foreach (var orderByDesc in left.OrderByDescending.Concat(right.OrderByDescending))
            AddOrderByDescending(orderByDesc);
    }
}
