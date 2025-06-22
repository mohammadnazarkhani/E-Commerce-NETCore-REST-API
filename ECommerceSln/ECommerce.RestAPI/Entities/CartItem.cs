using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class CartItem : AuditableEntityBase
    {
        public int Quantity { get; set; }
    }
}
