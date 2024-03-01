namespace Domain.Models
{
    public class Customer 
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Number { get; set; }
        public List<Order> Orders { get; set; }
    }
}