using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos
{
    // DTO for updating an existing product
    public record class UpdateProductDto(
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
