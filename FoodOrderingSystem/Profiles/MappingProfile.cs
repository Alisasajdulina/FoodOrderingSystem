using AutoMapper;
using FoodOrderingSystem.DTOs;
using FoodOrderingSystem.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodOrderingSystem.Profiles;

/// <summary>
/// Профиль маппинга AutoMapper
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Restaurant, RestaurantDto>().ReverseMap();
    }
}
