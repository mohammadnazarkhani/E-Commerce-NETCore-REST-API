using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    public class OrderItem : AuditableEntityBase
    {
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public required int Quantity { get; set; }
        
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        public required decimal Price { get; set; }
        
        public OrderItemStatus Status { get; set; } = OrderItemStatus.Pending;

        // Relationships
        public required Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public required Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public required Guid VendorId { get; set; }
        public Vendor Vendor { get; set; } = null!;
    }
}
