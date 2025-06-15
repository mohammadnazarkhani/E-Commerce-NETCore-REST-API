using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.RestAPI.Entities
{
    /// <summary>
    /// Represents a user in the e-commerce system.
    /// Has properties for first name, last name, and national code.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="IdentityUser{TKey}"/> with a <see cref="Guid"/> key type.
    /// Also implements <see cref="IAuditableEntity"/> to track creation and modification dates.
    /// </remarks>
    public class User : IdentityUser<Guid>, IAuditableEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? NationalCode { get; set; }

        // Auditable properties
        public required Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastModifiedAt { get; set; }
    }
}
