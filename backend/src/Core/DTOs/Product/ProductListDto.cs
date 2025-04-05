namespace Core.DTOs.Product;

public record class ProductListDto(
    long Id,
    string Name,
    decimal Price,
    Guid MainImageId
);