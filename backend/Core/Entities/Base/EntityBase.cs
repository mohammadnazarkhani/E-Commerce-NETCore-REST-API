using System;
using System.Runtime.InteropServices;
using Core.Entities.Interfaces;

namespace Core.Entities.Base;

public class EntityBase<TId> : IEntity<TId>
{
    public required TId Id { get; set; }
}
