using System;
using Core.Entities.Enums;

namespace Core.Entities.Interfaces;

public interface IEntityState
{
    EntityStatus Status { get; }
    void SetStatus(EntityStatus status);
}
