using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Entities.Base
{
    public class DeletedEntityBase : IDeletedEnttiy
    {
        public required DateTime DeletedAt { get; set; }
        public required Guid DeletedBy { get; set; }
    }
}
