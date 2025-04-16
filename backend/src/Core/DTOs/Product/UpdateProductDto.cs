using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Core.DTOs.Product;

public record class UpdateProductDto(
    [StringLength(200)]
    string? Name,
    [StringLength(2000)]
    string? Description,
    decimal? Price,
    int? CategoryId,
    [Range(0, int.MaxValue)]
    int? StockQuantity
);