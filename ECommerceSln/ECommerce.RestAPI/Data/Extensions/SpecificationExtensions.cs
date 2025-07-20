using System;
using ECommerce.RestAPI.Data.Specifications;
using ECommerce.RestAPI.Entities.Interfaces;
using Npgsql.Replication;

namespace ECommerce.RestAPI.Data.Extensions;

/// <summary>
/// Extension methods for specifications.
/// </summary>
public static class SpecificationExtensions
{
    /// <summary>
    /// Combines two specifications with AND
    /// </summary>
    public static ISpecification<TEntity> And<TEntity>(
        this ISpecification<TEntity> left,
        ISpecification<TEntity> right
    ) where TEntity : class, IEntity
    {

        return new AndSpecification<TEntity>(left, right);
    }

    /// <summary>
    /// Combines two specifications with OR
    /// </summary>
    public static ISpecification<TEntity> Or<TEntity>(
        this ISpecification<TEntity> left,
        ISpecification<TEntity> right
    ) where TEntity : class, IEntity
    {

        return new OrSpecification<TEntity>(left, right);
    }

    /// <summary>
    /// NEgates a specification
    /// </summary>
    public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> specification) where TEntity : class, IEntity
    {
        return new NotSpecification<TEntity>(specification);
    }
}
