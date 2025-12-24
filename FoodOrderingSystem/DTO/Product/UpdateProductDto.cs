namespace FoodOrderingSystem.DTO.Product
{
    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? RestaurantId { get; set; }
        public bool? IsAvailable { get; set; }
    }
}