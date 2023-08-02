using AutoMapper;
using Blog.DTO.CategoryDTO;
using Blog.DTO.PostDTO;
using Blog.DTO.SubscriptionDTO;
using Blog.DTO.UserDTO;
using Blog.Model;

namespace Blog.Common
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<Category, CategoryResponseDTO>();

            CreateMap<PostCreateDTO, Post>();
            CreateMap<PostUpdateDTO, Post>();
            CreateMap<Post, PostResponseDTO>();

            CreateMap<SubscriptionCreateDTO, Subscription>();
            CreateMap<SubscriptionUpdateDTO, Subscription>();
            CreateMap<Subscription, SubscriptionResponseDTO>();

            CreateMap<UserRegistrationDTO, User>();
            CreateMap<UserLoginDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserResponseDTO>();
        }
    }
}
