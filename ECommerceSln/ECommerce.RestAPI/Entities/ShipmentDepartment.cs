using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class ShipmentDepartment : AuditableEntityBase
    {
        // Relationships
        public required Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<Order> ShipedOrders { get; set; } = new List<Order>();
    }
}
