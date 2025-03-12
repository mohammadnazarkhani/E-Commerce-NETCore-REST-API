using System.ComponentModel.DataAnnotations;

namespace TondForooshApi.DTOs;

public record class CreateProductDto(
    [Required(ErrorMessage = "Name is required")] string Name,
    string? Description,
    [Required(ErrorMessage = "Price is required")][Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "Price must be greater than 0")] decimal Price,
    string? ImageUrl
);