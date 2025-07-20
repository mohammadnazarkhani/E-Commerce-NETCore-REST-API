using System;
using System.Linq.Expressions;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Specifications;

public class BuiltSpecification<TEntity> : ISpecification<TEntity> where TEntity : class, IEntity
{
    public Expression<Func<IEntity, bool>>? Criteria => throw new NotImplementedException();

    public List<Expression<Func<TEntity, object>>> Includes => throw new NotImplementedException();

    public List<string> IncludeStrings => throw new NotImplementedException();

    public List<Expression<Func<TEntity, object>>> OrderBy => throw new NotImplementedException();

    public List<Expression<Func<TEntity, object>>> OrderByDescending => throw new NotImplementedException();

    public int? Take => throw new NotImplementedException();

    public int? Skip => throw new NotImplementedException();

    public bool AsNoTracking => throw new NotImplementedException();

    public bool AsSplitQuery => throw new NotImplementedException();

    public Expression<Func<TEntity, object>>? GroupBy => throw new NotImplementedException();
}
