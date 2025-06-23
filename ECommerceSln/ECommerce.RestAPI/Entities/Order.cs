using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Enums;

namespace ECommerce.RestAPI.Entities
{
    public class Order : AuditableEntityBase
    {
        public required OrderStatus Status { get; set; }

        // Relationships
        public required Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Payment? payment { get; set; }
    }
}
