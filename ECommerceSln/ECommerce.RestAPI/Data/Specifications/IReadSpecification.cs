using System;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Specifications;

/// <summary>
/// Specification interface for read oprations
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public interface IReadSpecification<TEntity> : ISpecification<TEntity> where TEntity : class, IEntity
{
    /// <summary>
    /// Evaluates the specification against an entity
    /// </summary>
    /// <param name="entity">Entity to evaluate</param>
    /// <returns>True if entity staisfies the specification</returns>
    bool IsStatisfiedBy(TEntity entity);
}
