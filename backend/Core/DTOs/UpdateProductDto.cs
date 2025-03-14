using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public record class UpdateProductDto(
    [Required] long Id,
    string Name,
    string? Descirption,
    decimal Price,
    string ImageUrl
);
