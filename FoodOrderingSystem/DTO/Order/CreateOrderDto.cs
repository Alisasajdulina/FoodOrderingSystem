namespace FoodOrderingSystem.DTO.Order
{
    public class CreateOrderDto
    {
        public List<int> ProductIds { get; set; } = new();
    }

}
