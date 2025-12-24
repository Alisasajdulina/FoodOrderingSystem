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

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems!)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems!)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with id {id} not found.");
            }

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> CreateAsync(CreateOrderDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {dto.UserId} not found.");
            }

            var products = await _context.Products
                .Where(p => dto.ProductIds.Contains(p.Id))
                .ToListAsync();

            if (products.Count != dto.ProductIds.Count)
            {
                throw new ArgumentException("One or more products not found.");
            }

            var order = new Order
            {
                UserId = dto.UserId,
                Status = "Pending",
                TotalPrice = products.Sum(p => p.Price)
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            foreach (var product in products)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = product.Price
                };
                _context.OrderItems.Add(orderItem);
            }

            await _context.SaveChangesAsync();

            return await GetByIdAsync(order.Id);
        }

        public async Task<OrderDto> UpdateAsync(int id, UpdateOrderDto dto)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems!)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with id {id} not found.");
            }

            if (!string.IsNullOrEmpty(dto.Status))
            {
                order.Status = dto.Status;
            }

            if (dto.ProductIds != null && dto.ProductIds.Any())
            {
                _context.OrderItems.RemoveRange(order.OrderItems!);

                var products = await _context.Products
                    .Where(p => dto.ProductIds.Contains(p.Id))
                    .ToListAsync();

                if (products.Count != dto.ProductIds.Count)
                {
                    throw new ArgumentException("One or more products not found.");
                }

                foreach (var product in products)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = 1,
                        Price = product.Price
                    };
                    _context.OrderItems.Add(orderItem);
                }

                order.TotalPrice = products.Sum(p => p.Price);
            }

            await _context.SaveChangesAsync();
            return await GetByIdAsync(order.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with id {id} not found.");
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}