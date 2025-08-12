using eCommerce.Application.DependencyInjection;
using eCommerce.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();
Log.Logger.Information("Application is building 🏗️...............🏗️");

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(option =>
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//for taking auth token
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme,
    securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization like: `Bearer JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    option.OperationFilter<SecurityRequirementsOperationFilter>();
});
// Custom Services
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(option =>
    {
        option.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins(["https://localhost:7222", "https://localhost:7048"])
        .AllowCredentials();
    });
});

try
{
    var app = builder.Build();
    app.UseCors();
    app.UseSerilogRequestLogging();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
        app.UseSwagger();
        app.UseSwaggerUI();

        // Launch URLs in Chrome Incognito
        void OpenUrlsInChromeIncognito()
        {
            string swaggerUrl = "https://localhost:7222/swagger/index.html";
            string scalarUrl = "https://localhost:7222/scalar/v1";
            string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            string args = $"--incognito {swaggerUrl} {scalarUrl}";

            if (File.Exists(chromePath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = chromePath,
                    Arguments = args,
                    UseShellExecute = true
                });
            }
            else Console.WriteLine("Chrome is not installed at the default location.");
        }
        OpenUrlsInChromeIncognito();
    }

    app.UserInfrastructureService();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    Log.Logger.Information("Application is running 🚀...............🚀");
    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Error(ex, "Application failed to start 🥅");
}
finally
{
    Log.CloseAndFlush();
}