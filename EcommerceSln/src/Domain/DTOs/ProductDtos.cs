namespace Domain.DTOs;

public record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string SKU,
    bool IsAvailable,
    string CategoryName
);

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string SKU,
    Guid CategoryId
);

public record UpdateProductRequest(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string SKU,
    bool IsAvailable,
    Guid CategoryId
);
