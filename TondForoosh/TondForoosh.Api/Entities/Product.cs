namespace TondForoosh.Api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }

        // Foreign key for Product Category
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        // Foreign Key for Seller (User)
        public int UserId { get; set; }  // Each Product belongs to a Seller
        public User Seller { get; set; }  // Navigation property for Seller

        // Navigation properties    
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
