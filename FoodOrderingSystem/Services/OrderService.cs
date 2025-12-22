using AutoMapper;
using FoodOrderingSystem.Data;
using FoodOrderingSystem.DTO.Order;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateAsync(CreateOrderDto dto)
        {
            var products = await _context.Products
                .Where(p => dto.ProductIds.Contains(p.Id))
                .ToListAsync();

            var order = new Order
            {
                Products = products,
                TotalPrice = products.Sum(p => p.Price)
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
            throw new Exception("test");

        }

    }
}
