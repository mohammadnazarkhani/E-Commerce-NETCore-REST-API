using System;

namespace Core.Entities.Interfaces;

public interface IVersionable
{
    byte[] RowVersion { get; set; }
}
