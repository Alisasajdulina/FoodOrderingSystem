using AutoMapper;
using FoodOrderingSystem.DTOs;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Repositories;

namespace FoodOrderingSystem.Services;
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
    public async Task<IEnumerable<RestaurantDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<RestaurantDto>>(entities);
    }
}
