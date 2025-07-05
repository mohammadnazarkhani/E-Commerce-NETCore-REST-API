using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class Cart : AuditableEntityBase
    {
        // Relationships
        public  Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
