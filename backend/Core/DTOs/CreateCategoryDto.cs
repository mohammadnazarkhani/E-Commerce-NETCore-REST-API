using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public record CreateCategoryDto(
    [Required(ErrorMessage = "Name is required")] string Name);
