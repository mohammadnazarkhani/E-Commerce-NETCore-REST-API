using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Product;

public record class CreateProductDto
{
    [StringLength(200)]
    public required string Name { get; init; }

    [StringLength(2000)]
    public string? Description { get; init; }

    public required decimal Price { get; init; }

    [Required]
    public long CategoryId { get; init; }

    /// <summary>
    /// Display name or alt text for the product image
    /// </summary>
    public string ImageName { get; set; } = string.Empty;

    /// <summary>
    /// The image file uploaded
    /// </summary>
    public required IFormFile Image { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; init; }
}