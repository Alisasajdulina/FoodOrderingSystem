using AutoMapper;
using FoodOrderingSystem.DTOs;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Repositories;

namespace FoodOrderingSystem.Services;

/// <summary>
/// Сервис бизнес-логики ресторана
/// </summary>
public class RestaurantService
{
    private readonly IRepository<Restaurant> _repository;
    private readonly IMapper _mapper;

    public RestaurantService(
        IRepository<Restaurant> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить список ресторанов
    /// </summary>
    public async Task<IEnumerable<RestaurantDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<RestaurantDto>>(entities);
    }
}
