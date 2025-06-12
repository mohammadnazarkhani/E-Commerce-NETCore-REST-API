namespace ECommerce.RestAPI.Entities.Interfaces
{
    public interface IAuditableEntity : IEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime LastModifiedAt { get; set; }
    }
}
