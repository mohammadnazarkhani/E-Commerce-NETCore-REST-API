using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos.Product
{
    // DTO for creating a new product
    public record class CreateProductDto(
        [Required]
        [StringLength(100, MinimumLength = 3)]
        string Name,

        [Required]
        decimal Price,

        [Required]
        int ProductCategoryId,  // Category ID of the product

        [Required]
        int UserId  // Seller's User ID
    );
}
