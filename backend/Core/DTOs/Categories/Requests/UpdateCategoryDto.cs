using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Categories.Requests;

public record class UpdateCategoryDto(
    [Required] long Id,
    [Required] string Name
);
