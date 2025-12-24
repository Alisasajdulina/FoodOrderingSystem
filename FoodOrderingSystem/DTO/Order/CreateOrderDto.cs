namespace FoodOrderingSystem.DTO.Order
{
    public class CreateOrderDto
    {
        public required List<int> ProductIds { get; set; }
        public required int UserId { get; set; }
    }
}