namespace Core.DTOs.Category;

public record class CreateCategoryDto
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public int? ParentCategoryId { get; init; }
}