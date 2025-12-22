using FoodOrderingSystem.DTO.Order;

namespace FoodOrderingSystem.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с заказами
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Создать новый заказ
        /// </summary>
        Task<OrderDto> CreateAsync(CreateOrderDto dto);
    }
}
