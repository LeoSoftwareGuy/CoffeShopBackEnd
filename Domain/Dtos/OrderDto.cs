namespace Domain.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCounty { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
