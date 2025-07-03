using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    public class OrderItem : AuditableEntityBase
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
        
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        public decimal Price { get; set; }
        
        [Required]
        public OrderItemStatus Status { get; set; } = OrderItemStatus.Pending;

        // Relationships
        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required]
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        [Required]
        public Guid VendorId { get; set; }
        public Vendor Vendor { get; set; } = null!;
    }
}
