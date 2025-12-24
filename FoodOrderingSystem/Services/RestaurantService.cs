using AutoMapper;
using FoodOrderingSystem.Data;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RestaurantService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantDto>> GetAllAsync()
        {
            var entities = await _context.Restaurants.ToListAsync();
            return _mapper.Map<IEnumerable<RestaurantDto>>(entities);
        }

        public async Task<RestaurantDto> GetByIdAsync(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                throw new KeyNotFoundException($"Restaurant with id {id} not found.");
            }
            return _mapper.Map<RestaurantDto>(restaurant);
        }

        public async Task<RestaurantDto> CreateAsync(CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return _mapper.Map<RestaurantDto>(restaurant);
        }

        public async Task<RestaurantDto> UpdateAsync(int id, UpdateRestaurantDto dto)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                throw new KeyNotFoundException($"Restaurant with id {id} not found.");
            }

            _mapper.Map(dto, restaurant);
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
            return _mapper.Map<RestaurantDto>(restaurant);
        }

        public async Task DeleteAsync(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                throw new KeyNotFoundException($"Restaurant with id {id} not found.");
            }

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}