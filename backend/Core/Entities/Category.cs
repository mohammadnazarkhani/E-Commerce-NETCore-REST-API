using System;
using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities;

public class Category : AuditableEntity<int>
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    // Navigation property to a collection of Products
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
