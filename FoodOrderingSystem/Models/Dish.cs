using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Models
{
    public class Dish
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0.01, 1000)]
        public decimal Price { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}