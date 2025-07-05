using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class Product : AuditableEntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        // Relationships
        [Required]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        [Required]
        public Guid VendorId { get; set; }
        public Vendor Vendor { get; set; } = null!;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
