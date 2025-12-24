using AutoMapper;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.DTO.Order;
using FoodOrderingSystem.DTO.Product;
using FoodOrderingSystem.Models;

namespace FoodOrderingSystem.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.RestaurantName,
                    opt => opt.MapFrom(src => src.Restaurant != null ? src.Restaurant.Name : null));

            CreateMap<CreateProductDto, Product>();

            CreateMap<UpdateProductDto, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<CreateRestaurantDto, Restaurant>();

            CreateMap<UpdateRestaurantDto, Restaurant>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Order, OrderDto>();

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty));

            CreateMap<CreateOrderDto, Order>();
        }
    }
}