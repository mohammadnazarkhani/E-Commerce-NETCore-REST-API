using TondForoosh.Api.Entities;

public class SellerProduct
{
    public int Id { get; set; }

    // Foreign key for User (Seller)
    public required int UserId { get; set; }
    public required User Seller { get; set; }

    // Foreign key for Product
    public required int ProductId { get; set; }
    public required Product Product { get; set; }
}
