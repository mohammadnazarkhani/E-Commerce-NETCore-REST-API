using System;
using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities;

public class Category : AuditableEntity<int>
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    #region Relationship
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }

    public ICollection<Category> SubCategories { get; set; } = new List<Category>();

    // Navigation property to a collection of Products
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    #endregion
}
