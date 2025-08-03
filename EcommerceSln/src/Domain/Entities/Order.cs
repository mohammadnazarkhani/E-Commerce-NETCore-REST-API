using Domain.Entities.Base;
using Domain.Entities.Enums;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public string OrderNumber { get; set; } = string.Empty;
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    
    // Navigation properties
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public Guid ShippingAddressId { get; set; }
    public Address ShippingAddress { get; set; } = null!;
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
