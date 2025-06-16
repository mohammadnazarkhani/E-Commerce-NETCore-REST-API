using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class OrderItem : AuditableEntityBase
    {
        public required int Quantity { get; set; }
    }
}
