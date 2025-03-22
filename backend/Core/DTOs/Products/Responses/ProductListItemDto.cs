namespace Core.DTOs.Products.Responses;

public record class ProductListItemDto(
    long Id,
    string Name,
    decimal Price,
    string? ImageUrl
);
