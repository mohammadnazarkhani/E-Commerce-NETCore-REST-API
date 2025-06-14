using ECommerce.RestAPI.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    /// <summary>
    /// Represents a city within the e-commerce system for user addresses.
    /// Has a name and establishes a relationship with a province.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="AuditableEntityBase"/> to track creation and modification dates.
    /// Has a required name field and a relationship with the <see cref="Province"/> entity.
    /// </remarks>
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
