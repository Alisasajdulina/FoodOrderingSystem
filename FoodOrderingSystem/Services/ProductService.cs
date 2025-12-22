using AutoMapper;
using FoodOrderingSystem.Data;
using FoodOrderingSystem.DTO.Product;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Services
{
    /// <summary>
    /// Бизнес-логика для работы с продуктами
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        /// <inheritdoc />
        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }
    }
}
