namespace Core.DTOs.Category;

public record class CategoryListDto(
    int Id,
    string Name,
    int? ParentCategoryId,
    ICollection<CategoryDto>? SubCategories
);