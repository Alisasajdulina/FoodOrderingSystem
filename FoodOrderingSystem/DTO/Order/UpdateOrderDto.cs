namespace FoodOrderingSystem.DTO.Order
{
    public class UpdateOrderDto
    {
        public List<int>? ProductIds { get; set; }
        public string? Status { get; set; }
    }
}