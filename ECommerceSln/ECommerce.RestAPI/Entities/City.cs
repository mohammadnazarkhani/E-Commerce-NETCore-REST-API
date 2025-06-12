using ECommerce.RestAPI.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    public class City : AuditableEntityBase
    {
        [Length(2, 255)]
        public required string Name { get; set; }

        // Relationships
        public Guid ProvinceId { get; set; }
        public Province Province { get; set; } = null!;

        public ICollection<UserAddress> UserAddreses { get; set; } = new List<UserAddress>();
    }
}
