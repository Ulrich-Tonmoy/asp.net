using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.EMS.Data;
using WiredBrainCoffee.EMS.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContextFactory<EMSDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("EMSDb")));
builder.Services.AddScoped<StateContainer>();

var app = builder.Build();

// For development Only
await DatabseMigration(app.Services);
async Task DatabseMigration(IServiceProvider services)
{
    using var scope = services.CreateScope();
    using var ctx = scope.ServiceProvider.GetService<EMSDbContext>();
    if (ctx is not null)
        await ctx.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
