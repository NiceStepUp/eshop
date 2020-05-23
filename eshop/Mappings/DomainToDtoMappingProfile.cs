using AutoMapper;
using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public override string ProfileName => "DomainToDtoMappingProfile";

        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<Customer, CustomerDto>()
                .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<OrderItem, OrderItemDto>()
                .ForPath(dest => dest.Product.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForPath(dest => dest.Product.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForPath(dest => dest.Product.Category.Name, opt => opt.MapFrom(src => src.Product.Category.Name))
                .ForPath(dest => dest.Order.Id, opt => opt.MapFrom(src => src.Order.Id))
                .ForPath(dest => dest.Order.DatePlaced, opt => opt.MapFrom(src => src.Order.DatePlaced));

            CreateMap<Order, OrderDto>()
                .ForPath(dest => dest.Customer.FirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForPath(dest => dest.Customer.LastName, opt => opt.MapFrom(src => src.Customer.LastName))
                .ForPath(dest => dest.Customer.UserName, opt => opt.MapFrom(src => src.Customer.UserName))
                .ForPath(dest => dest.DatePlaced, opt => opt.MapFrom(src => src.DatePlaced))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));


            CreateMap<Shipping, ShippingDto>();

            CreateMap<ShoppingCartItem, ShoppingCartItemDto>()
                .ForPath(dest => dest.Product.Id, opt => opt.MapFrom(src => src.Product.Id))
                .ForPath(dest => dest.Product.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl))
                .ForPath(dest => dest.Product.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForPath(dest => dest.Product.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForPath(dest => dest.IdShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart.Id));
            CreateMap<ShoppingCart, ShoppingCartDto>();

            CreateMap<AuthenticationInfo, AuthenticationInfoDto>()
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.Customer.UserName))
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Customer.Id));
        }
    }
}
