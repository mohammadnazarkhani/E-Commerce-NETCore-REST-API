using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public record class UpdateCategoryDto(
    [Required] string Name
);
