namespace TondForoosh.Api.Dtos.CartItem
{
    public record class CartItemDto(
        int Id,
        int Quantity,
        string ProductName,
        decimal ProductPrice
    );
}
