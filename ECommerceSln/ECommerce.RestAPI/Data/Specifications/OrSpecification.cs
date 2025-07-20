using System;
using ECommerce.RestAPI.Data.Extensions;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Data.Specifications;

/// <summary>
/// Or specification for combining specifications
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class OrSpecification<TEntity> : BaseSpecification<TEntity> where TEntity : class, IEntity
{
    public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        : base(left.Criteria != null && right.Criteria != null
            ? left.Criteria.Or(right.Criteria)
            : left.Criteria ?? right.Criteria)
    { }
}
