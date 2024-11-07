namespace TondForoosh.Api.Entities
{
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

        // Navigation property for Products sold by the user
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
