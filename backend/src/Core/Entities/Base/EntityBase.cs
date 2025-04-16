using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Core.Entities.Interfaces;

namespace Core.Entities.Base;

public class EntityBase<TId> : IEntity<TId>
{
    [Required]
    public TId Id { get; set; } = default!;
}
