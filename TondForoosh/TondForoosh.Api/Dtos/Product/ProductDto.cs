namespace TondForoosh.Api.Dtos.Product
{
    // DTO for representing a product in lists (without detailed info)
    public record class ProductDto(
        int Id,

        string Name,

        decimal Price,

        string CategoryTitle,  // Category title

        string SellerUsername  // Seller's username
    );
}
