using AutoMapper;
using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Mappings
{
    public class DtoToDomainMappingProfile : Profile
    {
        public override string ProfileName => "DtoToDomainMappings";

        public DtoToDomainMappingProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<CustomerDto, Customer>();
                /*.ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));*/

            CreateMap<OrderItemDto, OrderItem>()
                .ForPath(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForPath(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));

            CreateMap<OrderDto, Order>()
                .ForPath(dest => dest.DatePlaced, opt => opt.MapFrom(src => src.DatePlaced))
                .ForPath(dest => dest.Shipping, opt => opt.MapFrom(src => src.Shipping))
                .ForPath(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Items));



            CreateMap<ShippingDto, Shipping>();
            CreateMap<ShoppingCartItemDto, ShoppingCartItem>();
            CreateMap<ShoppingCartDto, ShoppingCart>();
            CreateMap<AuthenticationInfoDto, AuthenticationInfo>();
            CreateMap<MessageDto, Message>();
        }
    }
}
