using TondForoosh.Api.Dtos.User;
using TondForoosh.Api.Common;

namespace TondForoosh.Api.Entities
{
    // Enum to define the roles of the user
    public enum UserRole
    {
        Admin,
        Seller,
        User
    }

    public class User : IUpdatable<UpdateUserDto>
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required UserRole Role { get; set; }

        // Navigation properties
        public ShoppingCart? ShoppingCart { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<SellerProduct> SellerProducts { get; set; } = new List<SellerProduct>();

        // Implementation of UpdateEntity method from IUpdatable interface
        public void UpdateEntity(UpdateUserDto userDto)
        {
            Username = userDto.Username;
            Role = userDto.Role;
        }
    }
}
