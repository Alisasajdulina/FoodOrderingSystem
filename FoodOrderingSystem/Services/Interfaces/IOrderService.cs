using FoodOrderingSystem.DTO.Order;

namespace FoodOrderingSystem.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateAsync(CreateOrderDto dto);
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        Task<OrderDto> UpdateAsync(int id, UpdateOrderDto dto);
        Task DeleteAsync(int id);
    }
}