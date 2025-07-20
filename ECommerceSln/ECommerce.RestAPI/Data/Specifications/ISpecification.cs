using System;
using System.Linq.Expressions;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Specifications;

/// <summary>
/// Base specification interface for query criteria
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public interface ISpecification<TEntity> where TEntity : class, IEntity
{
    /// <summary>
    /// Ceriteria expression for filtering
    /// </summary>
    Expression<Func<TEntity, bool>>? Criteria { get; }

    /// <summary>
    /// Include expressions for eager loading
    /// </summary>
    List<Expression<Func<TEntity, object>>> Includes { get; }

    /// <summary>
    /// Include expressions for eager loading as strings
    /// </summary>
    List<string> IncludeStrings { get; }

    /// <summary>
    /// Order by expressions
    /// </summary>
    List<Expression<Func<TEntity, object>>> OrderBy { get; }

    /// <summary>
    /// Order by descending expressions
    /// </summary>
    List<Expression<Func<TEntity, object>>> OrderByDescending { get; }

    /// <summary>
    /// Number of items to take (for pagination)
    /// </summary>
    int? Take { get; }

    /// <summary>
    /// Number of items to skip (for pagination)
    /// </summary>
    int? Skip { get; }

    /// <summary>
    /// Whether to enable change tracking
    /// </summary>
    bool AsNoTracking { get; }

    /// <summary>
    /// Whether to enable split queries
    /// </summary>
    bool AsSplitQuery { get; }

    /// <summary>
    /// Group by expression
    /// </summary>
    Expression<Func<TEntity, object>>? GroupBy { get; }
}
