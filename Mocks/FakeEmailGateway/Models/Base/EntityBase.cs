using System;

namespace FakeEmailGateway.Models.Base;

public class EntityBase : IEntity
{
    public Guid Id { get; set; }
}
