using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Enums;

namespace ECommerce.RestAPI.Entities
{
    public class Payment : AuditableEntityBase
    {
        public PaymentMethod Method { get; set; }
    }
}
