namespace TondForoosh.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }

        // Navigation properties
        public ShoppingCart? ShoppingCart { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
