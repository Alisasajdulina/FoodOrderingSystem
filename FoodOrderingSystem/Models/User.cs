using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}