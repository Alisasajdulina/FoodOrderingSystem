using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }

}