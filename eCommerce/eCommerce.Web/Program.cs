using eCommerce.Web;
using eCommerce.Web.Helper;
using eCommerce.Web.Helper.Auth;
using eCommerce.Web.Services;
using eCommerce.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NetcodeHub.Packages.Components.DataGrid;
using NetcodeHub.Packages.WebAssembly.Storage.Cookie;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddNetcodeHubCookieStorageService();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHttpClientHelper, HttpClientHelper>();
builder.Services.AddScoped<IApiRequestHelper, ApiRequestHelper>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<RefreshTokenHandler>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();

string apiUrl = builder.Configuration["ApiSettings:ApiUrl"]!;
builder.Services.AddHttpClient(Constant.ApiClient.Name, option =>
{
    option.BaseAddress = new Uri(apiUrl);
});
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();
builder.Services.AddVirtualizationService();

await builder.Build().RunAsync();