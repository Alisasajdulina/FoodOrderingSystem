using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public List<Product> Products { get; set; } = new();
    }

}
