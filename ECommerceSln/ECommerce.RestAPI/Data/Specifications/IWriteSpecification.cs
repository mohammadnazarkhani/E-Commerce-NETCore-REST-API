using System;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Specifications;

/// <summary>
/// Specification interface for write oprations
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public interface IWriteSpecification<TEntity> : ISpecification<TEntity> where TEntity : class, IEntity
{
    /// <summary>
    /// Validates an entity before write oprations
    /// </summary>
    /// <param name="entity">Entity to validate</param>
    /// <returns>Validation result</returns>
    ValidationResult Validate(TEntity entity);
}
