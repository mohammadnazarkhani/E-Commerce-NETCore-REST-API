using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public record class UpdateProductDto(
    [MinLength(3)]
    [Required]
    string Name,
    string? Description,
    [Range(0.01, double.MaxValue)]
    decimal Price,
    string? ImageUrl,
    int CategoryId
);