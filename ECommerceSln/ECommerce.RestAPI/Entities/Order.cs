using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Enums;

namespace ECommerce.RestAPI.Entities
{
    public class Order : AuditableEntityBase
    {
        public required OrderStatus Status { get; set; }
    }
}
