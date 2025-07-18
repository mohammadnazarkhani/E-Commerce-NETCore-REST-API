using System;
using System.Linq.Expressions;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Specifications;

/// <summary>
/// Base specification class providing common functionality
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public class BaseSpecification<TEntity> : IReadSpecification<TEntity> where TEntity : class, IEntity
{
    public Expression<Func<TEntity, bool>>? Ceriteria { get; private set; }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = new();
    public List<string> IncludeStrings { get; } = new();
    public List<Expression<Func<TEntity, object>>> OrderBy { get; } = new();
    public List<Expression<Func<TEntity, object>>> OrderByDescending { get; } = new();
     public int? Take { get; private set; }
    public int? Skip { get; private set; }
    public bool AsNoTracking { get; private set; }
    public bool AsSplitQuery { get; private set; }
    public Expression<Func<TEntity, object>>? GroupBy { get; private set; }

}
