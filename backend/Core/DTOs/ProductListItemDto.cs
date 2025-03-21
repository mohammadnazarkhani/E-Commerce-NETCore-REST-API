namespace Core.DTOs;

public record class ProductListItemDto(
    long Id,
    string Name,
    decimal Price,
    string ImageUrl
);