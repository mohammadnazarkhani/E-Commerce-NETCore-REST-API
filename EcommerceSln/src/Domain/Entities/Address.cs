using Domain.Entities.Base;

namespace Domain.Entities;

public class Address : BaseEntity
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    
    // Navigation properties
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public ICollection<Order> ShippingOrders { get; set; } = new List<Order>();
}
