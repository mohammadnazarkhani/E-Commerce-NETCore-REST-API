using ECommerce.RestAPI.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.RestAPI.Entities
{
    public class Vendor : AuditableEntityBase
    {
        public required string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }
}
