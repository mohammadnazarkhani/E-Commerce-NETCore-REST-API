using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities
{
    public class Question : AuditableEntityBase
    {
        public required string Quest { get; set; }
        public string? Answer { get; set; }
    }
}
