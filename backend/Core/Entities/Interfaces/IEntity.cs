using System;

namespace Core.Entities.Interfaces;

public interface IEntity<TId>
{
    TId Id { get; set; }
}
