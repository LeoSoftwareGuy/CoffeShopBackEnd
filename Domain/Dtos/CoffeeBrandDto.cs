namespace Domain.Dtos
{
    public class CoffeeBrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<MenuItemDto> MenuItems { get; set; }
    }
}
