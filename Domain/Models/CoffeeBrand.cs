namespace Domain.Models
{
    public class CoffeeBrand
    {
        public CoffeeBrand()
        {
            MenuItems = new HashSet<MenuItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
