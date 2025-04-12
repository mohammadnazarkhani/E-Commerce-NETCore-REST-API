using Core.DTOs.Category;

namespace Core.DTOs.Product;

public record class ProductDetailsDto(
    long Id,
    string Name,
    string? Description,
    decimal Price,
    int StockQuantity,
    Stack<CategoryDto> Categories,
    Guid MainImageId
);