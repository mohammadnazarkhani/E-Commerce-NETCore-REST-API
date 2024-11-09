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

        // Username should always be required (non-nullable)
        public required string Username { get; set; }

        // Password should be required (non-nullable), but will likely be handled as a hashed value
        public required string Password { get; set; }

        // Role is required, indicating the user's role (Admin, Seller, User)
        public required UserRole Role { get; set; }

        // Navigation properties
        // ShoppingCart can be null if a user does not have one, so it's nullable
        public ShoppingCart? ShoppingCart { get; set; }

        // Orders list is a required relationship (user must have at least one order or none)
        public List<Order> Orders { get; set; } = new List<Order>();

        // SellerProducts list is a required relationship (seller must have at least one product or none)
        public List<SellerProduct> SellerProducts { get; set; } = new List<SellerProduct>();
    }
}
