using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Enums;

namespace ECommerce.RestAPI.Entities
{
    public class Payment : AuditableEntityBase
    {
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        // Relationships
        public required Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public required Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
