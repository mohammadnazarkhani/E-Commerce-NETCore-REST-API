using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Entities.Base
{
    public class AuditableEntityBase : IAuditableEntity
    {
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastModifiedAt { get; set; }
    }
}
