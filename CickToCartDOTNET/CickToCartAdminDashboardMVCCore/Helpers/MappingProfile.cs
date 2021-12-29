using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CickToCart.Models;
using CickToCart.DTOS;
using CickToCart.Models.User;

namespace CickToCart.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductShowDto, Product>().ReverseMap();
            CreateMap<ProductEditDTO, Product>().ReverseMap();
            CreateMap<Product_RatingDto, Product_Rating>().ReverseMap();
            CreateMap<Product_colorDto, Product_color>().ReverseMap();
            CreateMap<Product_Size, Product_SizeDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryViewModel>().ReverseMap();
            CreateMap<Discount, DiscountViewModel>().ReverseMap();
            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModels>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailsViewModels>().ReverseMap();
            CreateMap<Order, OrderStatusViewModels>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Shipping, ShippingViewModels>().ReverseMap();
            CreateMap<Color, ColorViewModel>().ReverseMap();
            CreateMap<Size, SizeViewModel>().ReverseMap();
            CreateMap<Product, ProductDto2>().ReverseMap();
            CreateMap<Payment, PaymentViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartDetails, CartDetailsViewModel>().ReverseMap();
            CreateMap<CartDetails, CartDetailsViewModel2>().ReverseMap();
            CreateMap<UserListDTO, AppUser>().ReverseMap();
            CreateMap<AppUser, AppUser>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap();

            
            //CreateMap<Color, ShippingViewModels>().ReverseMap();
            //CreateMap<Size, ShippingViewModels>().ReverseMap();

        }
    }
}
