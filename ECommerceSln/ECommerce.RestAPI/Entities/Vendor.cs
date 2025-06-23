using ECommerce.RestAPI.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    public class Vendor : AuditableEntityBase
    {
        public required string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        // Relationships
        public required Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
