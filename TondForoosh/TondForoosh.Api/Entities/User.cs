using System.Collections.Generic;
using TondForoosh.Api.Dtos.User;

namespace TondForoosh.Api.Entities
{
    // Enum to define the roles of the user
    public enum UserRole
    {
        Admin,
        Seller,
        User
    }

    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required UserRole Role { get; set; }

        // Navigation properties
        public ShoppingCart? ShoppingCart { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<SellerProduct> SellerProducts { get; set; } = new List<SellerProduct>();
    }
}
