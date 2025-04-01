namespace Core.DTOs.Product;

public record class ProductDetailDto(
    long Id,
    string Name,
    string? Description,
    decimal Price,
    int StockQuantity,
    Queue<(int, string)> Categories,
    Guid MainImageId
);