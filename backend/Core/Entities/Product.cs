using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Base;
using Core.Entities.Interfaces;

namespace Core.Entities;

public class Product : AuditableEntity<long>, IVersionable
{
    [StringLength(200)]
    public required string Name { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;

    #region Relationships
    /// <summary>
    /// Relationship: Many-to-One with category
    /// Foreign Key: CategoryId
    /// </summary>
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    /// <summary>
    /// Relationship: One-to-One with ProductImage
    /// </summary>
    public ProductImage? MainImage { get; set; }
    #endregion
}
