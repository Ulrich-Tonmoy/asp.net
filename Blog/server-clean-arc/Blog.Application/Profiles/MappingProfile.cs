using AutoMapper;
using Blog.Application.DTOs;
using Blog.Domain;

namespace Blog.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CreateCategoryResponseDto>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryResponseDto>();
            CreateMap<Category, GetCategoryResponseDto>();

            CreateMap<CreatePostDto, Post>();
            CreateMap<Post, CreatePostResponseDto>();
            CreateMap<UpdatePostDto, Post>();
            CreateMap<Post, UpdatePostResponseDto>();
            CreateMap<Post, GetPostResponseDto>();

            CreateMap<CreateSubscriptionDto, Subscription>();
            CreateMap<Subscription, CreateSubscriptionResponseDto>();
            CreateMap<UpdateSubscriptionDto, Subscription>();
            CreateMap<Subscription, UpdateSubscriptionResponseDto>();
            CreateMap<Subscription, GetSubscriptionResponseDto>();

            CreateMap<UserRegistrationDto, User>();
            CreateMap<User, UserRegistrationResponseDto>();
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserLoginResponseDto>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UpdateUserResponseDto>();
        }
    }
}
