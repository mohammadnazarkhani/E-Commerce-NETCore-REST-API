using System;
using Core.Entities.Base;

namespace Core.Entities;

public class ProductImage : BaseMediaEntity
{
    /// <summary>
    /// Relationship: One-to-One with Product
    /// </summary>
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
