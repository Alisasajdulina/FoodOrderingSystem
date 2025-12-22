using FoodOrderingSystem.DTO.Product;

namespace FoodOrderingSystem.Services.Interfaces
{
    /// <summary>
    /// Сервис для работы с продуктами
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Получить список всех продуктов
        /// </summary>
        Task<IEnumerable<ProductDto>> GetAllAsync();

        /// <summary>
        /// Создать новый продукт
        /// </summary>
        Task<ProductDto> CreateAsync(CreateProductDto dto);
    }
}
