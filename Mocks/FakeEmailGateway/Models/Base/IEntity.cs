using System;

namespace FakeEmailGateway.Models.Base;

public interface IEntity
{
    Guid Id { get; set; }
}
