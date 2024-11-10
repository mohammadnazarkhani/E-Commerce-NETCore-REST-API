namespace TondForoosh.Api.Dtos.Order
{
    public record class OrderDto(
        int Id,
        decimal TotalPrice,
        DateTime OrderDate,
        string OrderStatus
    );
}
