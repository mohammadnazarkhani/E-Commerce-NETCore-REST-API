namespace Core.DTOs.Category;

public record class UpdateCategoryDto(
    string? Name,
    string? Description,
    int? ParentCategoryId
);