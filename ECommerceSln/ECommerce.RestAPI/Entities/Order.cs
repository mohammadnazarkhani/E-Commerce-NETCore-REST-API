using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Enums;

namespace ECommerce.RestAPI.Entities
{
    public class Order : AuditableEntityBase
    {
        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        // Relationships
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Payment? payment { get; set; }
    }
}
