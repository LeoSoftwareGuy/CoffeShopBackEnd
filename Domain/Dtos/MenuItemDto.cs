using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        [Required]
        public int CoffeeBrandId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal SmallPackagePrice { get; set; }
        [Required]
        public decimal MediumPackagePrice { get; set; }
        [Required]
        public decimal LargePackagePrice { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Origin { get; set; }
    }
}
