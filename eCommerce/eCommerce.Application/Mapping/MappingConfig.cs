using AutoMapper;
using eCommerce.Application.DTOs.Cart;
using eCommerce.Application.DTOs.Category;
using eCommerce.Application.DTOs.Identity;
using eCommerce.Application.DTOs.Product;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Cart;
using eCommerce.Domain.Entities.Identity;

namespace eCommerce.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CreateCategory, Category>();
            CreateMap<UpdateCategory, Category>();
            CreateMap<Category, GetCategory>();

            CreateMap<CreateProduct, Product>();
            CreateMap<UpdateProduct, Product>();
            CreateMap<Product, GetProduct>();

            CreateMap<CreateUser, AppUser>();
            CreateMap<LoginUser, AppUser>();

            CreateMap<PaymentMehtod, GetPaymentMethod>();
            CreateMap<CreateArchives, Archive>();
        }
    }
}
