using System;
using ECommerce.RestAPI.Entities.Interfaces;
using ECommerce.RestAPI.Data.Extensions;

namespace ECommerce.RestAPI.Data.Specifications;

public class NotSpecification<TEntity> : BaseSpecification<TEntity>
    where TEntity : class, IEntity
{
    public NotSpecification(ISpecification<TEntity> specification)
        : base(specification.Criteria?.Not())
    { }
}
