using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class Product : AuditableEntityBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Relationships
        public required Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public required Guid VendorId { get; set; }
        public Vendor Vendor { get; set; } = null!;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
