using ECommerce.RestAPI.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.RestAPI.Entities.Base
{
    public class AuditableEntityBase : IAuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastModifiedAt { get; set; }
    }
}
