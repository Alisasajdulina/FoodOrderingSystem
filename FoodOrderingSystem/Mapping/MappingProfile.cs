using AutoMapper;
using FoodOrderingSystem.DTO.Order;
using FoodOrderingSystem.DTO.Product;
using FoodOrderingSystem.Models;

namespace FoodOrderingSystem.Mapping
{
    /// <summary>
    /// Профиль маппирования между сущностями и DTO
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();

            // Order
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();
        }
    }
}
