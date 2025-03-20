namespace Core.DTOs;

public record class ProductSummary(
    long Id,
    string Name,
    decimal Price
);