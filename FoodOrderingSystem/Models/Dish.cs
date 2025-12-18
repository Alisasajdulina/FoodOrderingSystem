using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Models
{
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }

}