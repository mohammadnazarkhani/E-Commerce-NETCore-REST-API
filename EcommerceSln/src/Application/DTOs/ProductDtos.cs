namespace Application.DTOs;

public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string SKU,
    bool IsAvailable,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    CategoryDto Category
);

public record CreateProductDto(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string SKU,
    bool IsAvailable,
    Guid CategoryId
);

public record UpdateProductDto(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string SKU,
    bool IsAvailable,
    Guid CategoryId
);

public record ProductSummaryDto(
    Guid Id,
    string Name,
    decimal Price,
    bool IsAvailable
);
