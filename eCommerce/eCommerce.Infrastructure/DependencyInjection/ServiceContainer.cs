using eCommerce.Application.Services.Interfaces.Cart;
using eCommerce.Application.Services.Interfaces.Logging;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Identity;
using eCommerce.Domain.Interfaces;
using eCommerce.Domain.Interfaces.Authentication;
using eCommerce.Domain.Interfaces.Cart;
using eCommerce.Domain.Interfaces.Category;
using eCommerce.Infrastructure.Data;
using eCommerce.Infrastructure.Middleware;
using eCommerce.Infrastructure.Repositories;
using eCommerce.Infrastructure.Repositories.Authentication;
using eCommerce.Infrastructure.Repositories.Cart;
using eCommerce.Infrastructure.Repositories.Category;
using eCommerce.Infrastructure.Services;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace eCommerce.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(option =>
            option.UseSqlServer(config.GetConnectionString("Local"),
            sqlOption =>
            {
                sqlOption.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName);
                sqlOption.EnableRetryOnFailure();
            }).UseExceptionProcessor(),
            ServiceLifetime.Scoped);

            services.AddScoped<IGeneric<Product>, GenericRepository<Product>>();
            services.AddScoped<IGeneric<Category>, GenericRepository<Category>>();
            services.AddScoped(typeof(IAppLogger<>), typeof(SerilogLoggerAdapter<>));

            services.AddDefaultIdentity<AppUser>(option =>
            {
                option.SignIn.RequireConfirmedEmail = true;
                option.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                option.Password.RequiredLength = 8;
                option.Password.RequireDigit = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireLowercase = true;
                option.Password.RequiredUniqueChars = 1;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["JWT:Issuer"],
                    ValidAudience = config["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!))
                };
            });

            services.AddScoped<IUserManagement, UserManagement>();
            services.AddScoped<ITokenManagement, TokenManagement>();
            services.AddScoped<IRoleManagement, RoleManagement>();
            services.AddScoped<IPaymentMethod, PaymentMethodRepository>();
            services.AddScoped<IPaymentService, StripePaymentService>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<ICart, CartRepository>();

            Stripe.StripeConfiguration.ApiKey = config["Stripe:SecretKey"];

            return services;
        }

        public static IApplicationBuilder UserInfrastructureService(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }
    }
}
