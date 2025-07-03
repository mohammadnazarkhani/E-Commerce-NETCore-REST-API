using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Enums;

namespace ECommerce.RestAPI.Entities
{
    public class Payment : AuditableEntityBase
    {
        [Required]
        public PaymentMethod Method { get; set; }
        [Required]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        // Relationships
        [Required]
        public required Guid UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        public  Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
