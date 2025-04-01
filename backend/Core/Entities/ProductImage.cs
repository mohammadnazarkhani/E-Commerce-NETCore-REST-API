using System;
using Core.Entities.Base;

namespace Core.Entities;

public class ProductImage : BaseMediaEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
