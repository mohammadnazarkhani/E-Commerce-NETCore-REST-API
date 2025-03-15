using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class UpdateProductDto
{
    [Required]
    public long Id { get; set; }

    [MinLength(3)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }
}
