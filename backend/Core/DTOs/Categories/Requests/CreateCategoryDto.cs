using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Categories.Requests;

public record CreateCategoryDto(
    [Required(ErrorMessage = "Name is required")] string Name);
