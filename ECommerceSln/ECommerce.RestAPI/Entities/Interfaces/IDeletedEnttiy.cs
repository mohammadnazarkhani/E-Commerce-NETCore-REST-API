using Microsoft.AspNetCore.Identity;

namespace ECommerce.RestAPI.Entities.Interfaces
{
    public interface IDeletedEnttiy
    {
        DateTime DeletedAt { get; set; }
        Guid DeletedBy { get; set; }
    }
}
