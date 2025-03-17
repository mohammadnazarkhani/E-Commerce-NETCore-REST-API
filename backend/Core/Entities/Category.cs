using System;
using System.Collections.Generic;

namespace Core.Entities;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }

    // Navigation property to a collection of Products
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
