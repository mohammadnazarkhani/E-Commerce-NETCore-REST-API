namespace TondForoosh.Api.Dtos
{
    // DTO for detailed product info (including seller's info)
    public record class ProductDetailDto(
        int Id,

        string Name,

        decimal Price,

        string CategoryTitle,  // Category title

        string SellerUsername  // Seller's username

    );
}
