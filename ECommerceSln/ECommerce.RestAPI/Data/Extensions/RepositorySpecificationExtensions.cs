using System;
using ECommerce.RestAPI.Data.Repository;
using ECommerce.RestAPI.Data.Specifications;
using ECommerce.RestAPI.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ECommerce.RestAPI.Data.Extensions;

/// <summary>
/// Extension methods for using with repositories
/// </summary>
public static class RepositorySpecificationExtensions
{
    public static async Task<IEnumerable<T>> FindAsync<T>(
        this IRepository<T> repository,
        ISpecification<T> specification,
        CancellationToken cancellationToken = default
    ) where T : class, IEntity
    {
        var query = repository.AsQueryable();
        query = ApplySpecification(query, specification);
        return await Task.FromResult(query.ToList());
    }

    /// <summary>
    /// Counts entities using a specification
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="repository">Repository instance</param>
    /// <param name="specification">Specification to apply</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Count of entities matching the specification</returns>
    public static async Task<int> CountAsync<T>(
        this IRepository<T> repository,
        ISpecification<T> specification,
        CancellationToken cancellationToken = default
    ) where T : class, IEntity
    {
        var query = repository.AsQueryable();
        if (specification.Criteria != null)
            query = (IQueryable<T>)query.Where(specification.Criteria);

        return await Task.FromResult(query.Count());
    }

    /// <summary>
    /// Applies a specification to a queryable
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="query">Queryable to apply specification to</param>
    /// <param name="specification">Specification to apply</param>
    /// <returns>Specification to apply</returns>
    private static IQueryable<T> ApplySpecification<T>(IQueryable<T> query, ISpecification<T> specification) where T : class, IEntity
    {
        if (specification.Criteria != null)
            query = (IQueryable<T>)query.Where(specification.Criteria);

        query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

        if (specification.OrderBy.Any())
        {
            var orderedQuery = query.OrderBy(specification.OrderBy.First());
            query = specification.OrderBy.Skip(1).Aggregate(orderedQuery, (current, orderBy) => current.ThenBy(orderBy));
        }

        if (specification.OrderByDescending.Any())
        {
            var orderedQuery = query.OrderByDescending(specification.OrderByDescending.First());
            query = specification.OrderByDescending.Skip(1).Aggregate(orderedQuery, (current, orderBy) => current.ThenByDescending(orderBy));
        }

        if (specification.GroupBy != null)
            query = query.GroupBy(specification.GroupBy).SelectMany(x => x);

        if (specification.Skip.HasValue)
            query = query.Skip(specification.Skip.Value);

        if (specification.Take.HasValue)
            query = query.Take(specification.Take.Value);

        return query;
    }
}
