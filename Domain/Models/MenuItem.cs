namespace Domain.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int CoffeeBrandId { get; set; }
        public string Name { get; set; }
        public decimal SmallPackagePrice { get; set; }
        public decimal MediumPackagePrice { get; set; }
        public decimal LargePackagePrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public CoffeeBrand CoffeeShop { get; set; }
    }
}
