using FoodOrderingSystem.DTO.Product;
using FoodOrderingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingSystem.Controllers
{
    /// <summary>
    /// Контроллер для работы с продуктами
    /// </summary>
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получить список всех продуктов
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Создать новый продукт
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
    }
}
 