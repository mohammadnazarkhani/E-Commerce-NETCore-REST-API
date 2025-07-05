using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.RestAPI.Entities.Base;
using ECommerce.RestAPI.Entities.Enums;
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
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? NationalCode { get; set; }

        [Required]
        public UserRole Role { get; set; } = UserRole.User;

        // Auditable properties
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastModifiedAt { get; set; }

        // Relationships
        public UserAddress? Address { get; set; }

        public ICollection<Review>? Reviews { get; set; } = new List<Review>();

        public ICollection<Question>? AskedQuestions { get; set; } = new List<Question>();

        public Vendor? Vendor { get; set; }

        public Cart? Cart { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
