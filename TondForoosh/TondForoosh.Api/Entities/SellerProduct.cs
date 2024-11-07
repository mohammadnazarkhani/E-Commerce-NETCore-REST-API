using TondForoosh.Api.Entities;

public class SellerProduct
{
    public int Id { get; set; }

    // Foreign key for User (Seller)
    public int UserId { get; set; }
    public User Seller { get; set; }

    // Foreign key for Product
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
