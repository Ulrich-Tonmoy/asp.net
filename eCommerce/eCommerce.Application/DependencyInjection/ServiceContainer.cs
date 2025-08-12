using eCommerce.Application.Mapping;
using eCommerce.Application.Services;
using eCommerce.Application.Services.Authentication;
using eCommerce.Application.Services.Cart;
using eCommerce.Application.Services.Interfaces;
using eCommerce.Application.Services.Interfaces.Authentication;
using eCommerce.Application.Services.Interfaces.Cart;
using eCommerce.Application.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eCommerce.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
