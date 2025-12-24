using FoodOrderingSystem.DTO;
namespace FoodOrderingSystem.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDto>> GetAllAsync();
        Task<RestaurantDto> GetByIdAsync(int id);
        Task<RestaurantDto> CreateAsync(CreateRestaurantDto dto);
        Task<RestaurantDto> UpdateAsync(int id, UpdateRestaurantDto dto);
        Task DeleteAsync(int id);
    }
}