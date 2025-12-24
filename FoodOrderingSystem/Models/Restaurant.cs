using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        // Навигационные свойства
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}