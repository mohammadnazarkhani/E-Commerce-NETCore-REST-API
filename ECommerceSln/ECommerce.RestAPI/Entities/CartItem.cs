using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class CartItem : AuditableEntityBase
    {
        public int Quantity { get; set; }

        // Relationships
        public required Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public required Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;
    }
}
