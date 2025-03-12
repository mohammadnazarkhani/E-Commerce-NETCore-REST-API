using System.ComponentModel.DataAnnotations;

namespace TondForooshApi.DTOs;

public record class CreateProductDto(
    [Required] string Name,
    string? Description,
    [Required][Range(typeof(decimal), "1", "79228162514264337593543950335")] decimal Price,
    string? ImageUrl
);